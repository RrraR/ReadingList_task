import {Link, useParams} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import {useEffect, useState} from "react";
import api from "../api";
import {Button, Table} from "react-bootstrap";
import axios from "axios";

export default function Collections() {
    const [collectionInfo, setCollectionInfo] = useState([]);
    const [collectionName, setCollectionName] = useState('');
    const [addCollectionIsShown, setAddCollectionIsShown] = useState(false);

    useEffect(() => {
        api.get(`/Collections`)
            .then(function (response) {
                setCollectionInfo(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .finally(function () {
                // always executed
            });
    }, [])

    const renderRow = collection => (
        <tr key={collection.id}>
            {/*<td><Link to={`/library/${book.id}`}>{book.name}</Link></td>*/}
            <td><Link to={`/collections/${collection.id}`}>{collection.name}</Link></td>
        </tr>
    )

    function buttonAddCollectionHandler() {
        setAddCollectionIsShown(current => !current);
    }

    const addCollectionHandler = () => {
        api.post(`/Collections/name`, collectionName,
            {
                headers: {
                    'content-type': 'application/json'
                }
            }
        ).then(r => r.status == 200 ? window.location = "/collections" : console.log(r));
    };

    const handleCollectionChange = (event) => {
        setCollectionName(event.target.value);
    };

    return (
        <div>
            <Link to="/" className="btn btn-primary">Go to your library</Link>
            {<Button onClick={buttonAddCollectionHandler}>Add new collection</Button>}

            {addCollectionIsShown && (
                <div>
                    <h6>Add new collection</h6>
                </div>
            )}
            {addCollectionIsShown && (<div>
                <label>
                    Name:
                    <input
                        type="text"
                        id="collectionName"
                        name="collectionName"
                        onChange={handleCollectionChange}
                        value={collectionName}/>
                </label>
                <Button onClick={addCollectionHandler}>Create new collection</Button>
            </div>)}
            
            <Table>
                <thead>
                <tr>
                    <th>Collection name</th>
                </tr>
                </thead>
                <tbody>
                {collectionInfo.map(renderRow)}
                </tbody>
            </Table>
            {/*<div>Collection name: {collectionInfo.name}</div>*/}
        </div>
    );
}