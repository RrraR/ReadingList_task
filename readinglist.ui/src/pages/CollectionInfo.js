import {Link, useParams} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import {useEffect, useState} from "react";
import api from "../api";
import {Button, Table} from "react-bootstrap";
import axios from "axios";

export default function CollectionInfo() {
    const [collectionInfo, setCollectionInfo] = useState([]);
    const {id} = useParams();

    useEffect(() => {
        api.get(`/Collections/${id}`)
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

    const deleteCollectionHandler = () => {
        api.delete(`/collections/${collectionInfo.id}`, {
            id: collectionInfo.id
        }).then(r => r.status == 200 ? window.location = "/collections" : console.log(r)
            //r => console.log(r)
        );
    };
    
    return(
        <div>
            {<Button onClick={deleteCollectionHandler}>Delete collection</Button>}
            <div>Collection name: {collectionInfo.name}</div>
        </div>
    )
}
