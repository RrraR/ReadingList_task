import './App.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import UserBookList from "./pages/UserBookList";
import UserBook from "./pages/UserBook";
import Library from "./pages/Library"
import LibraryBook from "./pages/LibraryBook"
import Collections from "./pages/Collections";
import CollectionInfo from "./pages/CollectionInfo";

export default function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<UserBookList/>}/>
                <Route path="/book/:id" element={<UserBook/>}/>
                <Route path="/library" element={<Library/>}></Route>
                <Route path="/library/:id" element={<LibraryBook/>}></Route>
                <Route path="/collections" element={<Collections/>}></Route>
                <Route path="/collections/:id" element={<CollectionInfo/>}></Route>

            </Routes>
        </BrowserRouter>
    );
}
