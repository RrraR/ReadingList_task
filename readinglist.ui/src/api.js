import axios from 'axios';

export default axios.create({
    baseURL: `https://localhost:7178/api`
});

// export function getBooks() {
//     return 
// }
//
// export function getBookInfo(id) {
//     axios.get('/book/12345')
//         .then(function (response) {
//             // handle success
//             return response
//         })
//         .catch(function (error) {
//             // handle error
//             console.log(error);
//         })
//         .finally(function () {
//             // always executed
//         });
// }