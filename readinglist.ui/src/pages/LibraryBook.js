import {Link, useParams} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import {useEffect, useState} from "react";
import api from "../api";
import {Button} from "react-bootstrap";
import axios from "axios";

export default function LibraryBook() {
    const [bookInfo, setBookInfo] = useState([]);
    const {id} = useParams();

    useEffect(() => {
        api.get(`/library/${id}`)
            .then(function (response) {
                setBookInfo(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .finally(function () {
                // always executed
            });
    }, [])

    const addBookHandler = () => {
        api.post(`/books/${bookInfo.id}`, {
            id: bookInfo.id
        }).then(r => console.log(r));
    };

    return (
        <div className="container justify-content-center">

            {!bookInfo.userBookId ?
                    <Button onClick={addBookHandler}>Add book to your library</Button> :
                    <Link className="btn btn-primary" to={`/book/${bookInfo.userBookId}`}>See in your library</Link>}
            
            <div className="d-flex flex-column">
                <div className="p-2">Book name: {bookInfo.name}</div>
                <div className="p-2">Book author: {bookInfo.author}</div>
                <div className="p-2">Book length: {bookInfo.length}</div>
                <div className="p-2">Book language: {bookInfo.language}</div>
                <div className="p-2">Book genre: {bookInfo.genre}</div>
                <div className="p-2">Book is part of series: {bookInfo.series}</div>
            </div>
        </div>
    );
}