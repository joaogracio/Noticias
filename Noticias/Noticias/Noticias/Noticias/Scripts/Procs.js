function getNoticias() {
    return fetch("/api/noticias", {
        headers: { 'Accept': 'application/json' }
    })
        .then(resposta => resposta.json()); // JSON dos agentes.
    //.then(function(resposta){
    // resposta.json});
}

function getNoticia(n) {
    //console.log(id);
    //document.querySelector("#root").style.display = "none";
    //var drivers = document.querySelector("#drivers");
    var url = '/api/noticias/' + n;
    return fetch(url, {
        headers: { 'Accept': 'application/json' }
    })
        .then(resposta => resposta.json())
        //.then(function (resposta) {
        //   adicionarNoticiaCapa(resposta);
        //})
        .catch(function (error) {
            console.log(error);
        });
}

