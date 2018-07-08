document.addEventListener('DOMContentLoaded', function main(e) {

    getNoticias
        .then(function (data) {
            categories(data);
        })
        .catch(function (error) {
            console.log(error);
        }); 
});

// Adicionar evento para submissão...
document.querySelector('#adicionar-noticia').addEventListener('submit', function (e) {
    // Prevenir que o browser submeta o formulário por nós...
    e.preventDefault();

    let form = this;


    let noticia = {
        Titulo: form.querySelector('[name=titulo]').value,
        Resumo: form.querySelector('[name=resumo]').value,
        Texto: form.querySelector('[name=texto]').value,
        CategoriaFK: form.querySelector('[name=categoria]').value
    };

    // Converter em JSON.
    let jsonData = JSON.stringify(noticia);

    // Usar o fetch para enviar o JSON, como POST (quero CRIAR, logo POST)
    fetch('/api/noticias', { // Ver  Api/AgentesController, método PostAgentes
        method: 'post', // Quero usar POST
        headers: { 'Content-Type': 'application/json' }, // Vou enviar JSON
        body: jsonData // Dados a enviar.
    })
        .then(resposta => { // Resposta da criação
            if (resposta.ok) { // "ok" indica se 200 <= status < 300.
                return resposta.json(); // JSON do Noticia criada.
            } else {
                // Erro (vai parar ao catch abaixo)
                return resposta.json()
                    .then(erro => Promise.reject(erro));
            }
        })
        // Agente criado. "novaNoticia" é o objeto do noticia.
        // vamos adicionar o novo agente ao ecrã.
        .then(novaNoticia => adicionarNoticia(noticia))
        // Ocorreu um erro.
        .catch(erro => {
            console.error(erro);
        });
});

document.querySelector('#alterar-noticia').addEventListener('submit', function (e) {
    // Prevenir que o browser submeta o formulário por nós...
    e.preventDefault();

    let form = this;


    let noticia = {
        Titulo: form.querySelector('[name=titulo]').value,
        Resumo: form.querySelector('[name=resumo]').value,
        Texto: form.querySelector('[name=texto]').value,
        CategoriaFK: form.querySelector('[name=categoria]').value
    };

    NoticiaID = 1;

    // Converter em JSON.
    let jsonData = JSON.stringify(noticia);

    // Usar o fetch para enviar o JSON, como POST (quero CRIAR, logo POST)
    fetch('/api/noticias/' + NoticiaID, { // Ver  Api/AgentesController, método PostAgentes
        method: 'put', // Quero usar POST
        headers: { 'Content-Type': 'application/json' }, // Vou enviar JSON
        body: jsonData // Dados a enviar.
    })
        .then(resposta => { // Resposta da criação
            if (resposta.ok) { // "ok" indica se 200 <= status < 300.
                return resposta.json(); // JSON do Noticia criada.
            } else {
                // Erro (vai parar ao catch abaixo)
                return resposta.json()
                    .then(erro => Promise.reject(erro));
            }
        })
        // Agente criado. "novaNoticia" é o objeto do noticia.
        // vamos adicionar o novo agente ao ecrã.
        .then(novaNoticia => adicionarNoticia(noticia))
        // Ocorreu um erro.
        .catch(erro => {
            console.error(erro);
        });
});

document.querySelector('#remover-noticia').addEventListener('submit', function (e) {
    // Prevenir que o browser submeta o formulário por nós...
    e.preventDefault();

    let form = this;

    let noticiaID = form.querySelector('[name=categoria]').value;

    // Usar o fetch para enviar o JSON, como POST (quero CRIAR, logo POST)
    fetch('/api/noticias/' + noticiaID, { // Ver  Api/AgentesController, método PostAgentes
        method: 'delete'
    })
        .then(resposta => { // Resposta da criação
            if (resposta.ok) { // "ok" indica se 200 <= status < 300.
                return resposta.json(); // JSON do Noticia criada.
            } else {
                // Erro (vai parar ao catch abaixo)
                return resposta.json()
                    .then(erro => Promise.reject(erro));
            }
        })
        // Agente criado. "novaNoticia" é o objeto do noticia.
        // vamos adicionar o novo agente ao ecrã.
        .then(novaNoticia => adicionarNoticia(noticia))
        // Ocorreu um erro.
        .catch(erro => {
            console.error(erro);
        });
});