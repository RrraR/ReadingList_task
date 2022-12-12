import {Link, useParams} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import {useEffect, useState} from "react";
import api from "../api";
import {Button, Form, Spinner, Table} from "react-bootstrap";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import Select from 'react-select'
import moment from 'moment'

export default function UserBook() {
    const [isLoading, setIsLoading] = useState(true);
    const [bookInfo, setBookInfo] = useState({});
    const [isEditing, setIsEditing] = useState(false);
    const [isFinished, setIsFinished] = useState(false);
    const [startDate, setStartDate] = useState(new Date());
    const [finishDate, setFinishDate] = useState(new Date());
    const [readingPriority, setReadingPriority] = useState(1);
    const [collections, setCollections] = useState([]);
    const [selectedCollections, setSelectedCollections] = useState([]);
    const {id} = useParams();

    useEffect(() => {
            setIsLoading(true);


        api.get(`/Collections`).then(function (response) {
            const mapped = response.data.map(col => ({
                value: col.id,
                label: col.name
            }))
            setCollections(mapped);
        })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .finally(function () {
                // always executed
            });
        
        
            api.get(`/books/${id}`)
                .then(function (response) {
                    setBookInfo(response.data);
                    setIsFinished(response.data.isFinished)
                    if (response.data.isFinished) {
                        setReadingPriority(0);
                    }
                    const myDate = moment.utc(response.data.startDate, 'YYYY-MM-DD').toDate();
                    setStartDate(myDate);
                    setIsLoading(false);
                })
                .catch(function (error) {
                    // handle error
                    console.log(error);
                })
                .finally(function () {
                    // always executed
                });

            
        }, []
    );

    const deleteBookHandler = () => {
        api.delete(`/books/${bookInfo.id}`, {
            id: bookInfo.id
        }).then(r => r.status == 200 ? window.location = "/" : console.log(r)
            //r => console.log(r)
        );
    };

    function editBookHandler() {
        setIsEditing(true);
    }

    function markAsFinished(event) {
        setIsFinished(event.target.checked);
        setReadingPriority(0);
    }

    function saveBookHandler() {
        setReadingPriority(readingPriority)
        setIsEditing(false);

        api.put(`/books/${bookInfo.id}`,
            {
                isFinished: isFinished,
                startDate: moment(startDate).format(moment.HTML5_FMT.DATE),
                finishDate: isFinished ? moment(finishDate).format(moment.HTML5_FMT.DATE) : null,
                readingPriority: readingPriority,
                collections: selectedCollections.map(c => ({
                    name: c.label,
                    id: c.value
                }))
            }
        ).then(r => setBookInfo(r.data));

    }

    const readingPriorityInput = (event) => {
        if (isFinished){
            const value = 0;
            setReadingPriority(value)
        }
        else {
            const value = Math.max(1, Math.min(10, Number(event.target.value)));
            setReadingPriority(value)
        }
    }

    function collectionsHandler(event) {
        //console.log(event);
        setSelectedCollections(event)
    }

    if (isLoading) {
        return <Spinner></Spinner>
    }

    function getMatched() {
        // console.log(collections);
        // console.log(bookInfo.collections)
        return collections.filter(x => bookInfo?.collections.includes(x.label))
    }

    return (
        <div>
            {<Button onClick={deleteBookHandler}>Remove book</Button>}

            {!isEditing && (<Button onClick={editBookHandler}>Edit book</Button>)}

            {isEditing && (<Button onClick={saveBookHandler}>Save book</Button>)}


            <Form>
                <div>Book name: {bookInfo.name}</div>
                <div>Book author: {bookInfo.author}</div>
                <div>Book length: {bookInfo.length}</div>
                <div>Book language: {bookInfo.language}</div>
                <div>Book genre: {bookInfo.genre}</div>
                <div>Book is part of series: {bookInfo.series}</div>


                <Form.Check
                    inline
                    onChange={markAsFinished}
                    checked={isFinished}
                    type={"checkbox"}
                    label={"Is book finished"}
                    disabled={!isEditing}
                />


                {!isEditing && (
                    <div>Start reading on:</div>)}

                {isEditing && (<div>
                    Edit start date:
                </div>)}

                <DatePicker disabled={!isEditing}
                            selected={startDate}
                            onSelect={(date: Date) => setStartDate(date)}/>


                {isFinished && !isEditing && (<div>Finished reading on:</div>)}

                {isFinished && isEditing && (<div>
                    Edit finish date:
                </div>)}

                {isFinished && (<DatePicker disabled={!isEditing}
                                            selected={finishDate}
                                            onSelect={(date: Date) => setFinishDate(date)}/>
                )}


                {!isFinished && !isEditing && (<div>Reading priority: {bookInfo.readingPriority}</div>)}

                {isEditing && (<div>
                    Edit reading priority:
                    <input
                        type="number"
                        placeholder={bookInfo.redingPriority?.toString()}
                        value={readingPriority?.toString()}
                        onChange={readingPriorityInput}
                        disabled={isFinished}
                    />
                </div>)}

                <div>
                    <div>
                        Collections:
                    </div>
                    <Select
                        isDisabled={!isEditing}
                        defaultValue={getMatched()}
                        isMulti
                        name="collections"
                        options={collections.map(col => ({
                            value: col.value,
                            label: col.label
                        }))}
                        className="basic-multi-select"
                        classNamePrefix="select"
                        onChange={collectionsHandler}
                    />
                    {/*Collections: {bookInfo.collections}*/}
                </div>

                {/*{!isEditing && (collections.length === 0 ? <div>Collections: no collections</div> :  <div>Collections: {bookInfo.collections}</div>)}*/}
                {/*{! (<div>Collections: {bookInfo.collections}</div>)}*/}
            </Form>
        </div>
    )
}