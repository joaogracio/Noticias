document.addEventListener('DOMContentLoaded', function main(e) {

    getNoticias()
        .then(function (data) {
            categories(data);
        })
        .catch(function (error) {
            console.log(error);
        }); 
});
