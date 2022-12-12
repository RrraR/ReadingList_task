import {Button, Form, Row, Table} from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.css';
import {useEffect, useMemo, useState} from "react";
import api, {getBooks} from "../api";
import axios from "axios";
import {Link} from "react-router-dom";

export default function Library() {
    const [books, setBooks] = useState([]);
    const [query, setQuery] = useState('');
    const [bookList, setBookList] = useState([]);

    useEffect(() => {
        api.get('/Library')
            .then(function (response) {
                setBooks(response.data);
                setBookList(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .finally(function () {
                // always executed
            });
    }, [])

    const renderRow = book => (
        <tr key={book.id}>
            <td><Link to={`/library/${book.id}`}>{book.name}</Link></td>
            <td>{book.author}</td>
        </tr>
    )

    function search(books) {
        const search_parameters = ["name"];
        return books.filter(
            (book) =>
                search_parameters.some((parameter) =>
                    book[parameter].toString().toLowerCase().includes(query)
                )
        );
    }

    function setQueryHandler(e) {
        const data = Object.values(bookList)
        
        setQuery(e.target.value)
        setBooks(search(data))
    }

    return (<div>
        <Link to="/" className="btn btn-primary">Go to your library</Link>

        <div htmlFor="search-form">
            <input
                name="search-form"
                id="search-form"
                className="search-input"
                type="search"
                placeholder='Search book'
                onChange={setQueryHandler}
            />
        </div>

        <Table>
            <thead>
            <tr>
                <th>Book name</th>
                <th>Author</th>
            </tr>
            </thead>
            <tbody>
            {books.map(renderRow)}

            </tbody>
        </Table>
    </div>);
}