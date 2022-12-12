import {Button, Dropdown, Form, Row, Table} from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.css';
import {useEffect, useState} from "react";
import api, {getBooks} from "../api";
import axios from "axios";
import {Link} from "react-router-dom";

function UserBookList() {
    const [books, setBooks] = useState([]);
    const [showRead, setShowRead] = useState(false);
    const [collection, setCollection] = useState('');
    const [collectionsList, setCollectionsList] = useState([]);

    useEffect(() => {
        getBooks();
        api.get(`/Collections`)
            .then(function (response) {
                setCollectionsList(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .finally(function () {
                // always executed
            });
    }, []);

    useEffect( () => {
        getBooks()
    }, [collection, showRead])
        
    
    
    const getBooks =() => {
        const params = new URLSearchParams();
        params.append('collectionname', collection);
        params.append('showfinished', showRead.toString());

        api.get(`/books?${params}`)
            .then(function (response) {
                setBooks(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .finally(function () {
                // always executed
            });
    };


    // const addBookHandler = () => {
    //     const newBook = {
    //         id: books.length + 1,
    //         name: "bjj",
    //         author: "kkkk"
    //     }
    //     setBooks([...books, newBook])
    // };

    const showReadHandler = (event) => {
        setShowRead(event.target.checked);
    }

    const renderRow = book => (
        <tr key={book.id}>
            <td><Link to={`/book/${book.id}`}>{book.name}</Link></td>
            <td>{book.author}</td>
            
            {book.isFinished ? <td>No priority</td> : <td>{book.readingPriority}</td>}
            <td>
                {
                    book.isFinished?.toString() === 'true' ? ' Yes' : ' No'
                }
            </td>
            {/*<td>{book.isFinished.toString()}</td>*/}
        </tr>
    )

    function showCollectionHandler(event) {
        setCollection(event.currentTarget.value);
    }

    return (
        <div className="App">
            {/*<Button onClick={addBookHandler}>Add book</Button>*/}
            <Link to="/library" className="btn btn-primary">Add Book</Link>
            <Link to="/collections" className="btn btn-primary">View collections</Link>

            {/*{<Button onClick={addCollectionHandler}>Collections</Button>}*/}
            <Form>
                <Form.Check
                    inline
                    onChange={showReadHandler}
                    checked={showRead}
                    type={"checkbox"}
                    label={"show finished books"}
                />
            </Form>

            <Form.Select onChange={showCollectionHandler} value={collection} aria-label="Default select example">
                <option value={''}>Show all</option>
                {collectionsList.map(c => (<option key={c.id} value={c.name}>{c.name}</option>))}
            </Form.Select>

            <Table>
                <thead>
                <tr>
                    <th>Book name</th>
                    <th>Author</th>
                    <th>Reading Priority</th>
                    <th>Is finished</th>
                </tr>
                </thead>
                <tbody>
                {showRead ? books.filter(book => book.isFinished).map(renderRow) : books.map(renderRow)}
                </tbody>
            </Table>

        </div>
    );
}

export default UserBookList;