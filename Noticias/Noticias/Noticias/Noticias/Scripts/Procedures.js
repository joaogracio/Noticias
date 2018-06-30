function divNoticia(noticia) {

    let template = document.querySelector('#template-noticia').cloneNode(true);

    template.removeAttribute('id');

    let titulo = template.querySelector('h2');
    titulo.innerHTML = noticia.Titulo;

    let texto = template.querySelector('p:nth-child(2)');
    texto.innerHTML = noticia.Texto;

    let link = template.querySelector('p:nth-child(3) > a');
    link.href = null;

    return template;
}

function divCapa(noticia) {

    let template = document.querySelector('#template-capa').cloneNode(true);

    template.removeAttribute('id');

    let titulo = template.querySelector('h1');
    titulo.innerHTML = noticia.Titulo;

    let texto = template.querySelector('p:nth-child(2)');
    texto.innerHTML = noticia.Texto;

    //let link_imagem = template.querySelector('p:nth-child(3)');

    let link_imagem = template.querySelector('div > a');
    //imagem.src = '~/Imagem/' + noticia.Imagens[0].Directorio;

    let imagem = template.querySelector('div > img');
    imagem.src = '/Images/' + noticia.Imagens[0].Directorio;

    return template;
}

function adicionarNoticia(noticia) {
    let template = divNoticia(noticia);

    let grelha = document.querySelector('#root-noticias');

    grelha.appendChild(template);
}

function adicionarNoticiaCapa(noticia) {
    let template = divCapa(noticia);

    let grelha = document.querySelector('#root-noticias');

    grelha.appendChild(template);
}

function adicionarCategoriaSelect(categorias, select) {
    //console.log(categorias.length);

    categorias.forEach(function (catg) {
        let opt = catg.CategoriaID;
        let el = document.createElement("option");
        el.textContent = catg.Nome;
        el.value = opt;
        select.appendChild(el);
    });
}

function adicionarNoticiasSelect(noticias, select) {
    noticias.forEach(function (catg) {
        let opt = catg.NoticiasID;
        let el = document.createElement("option");
        el.textContent = catg.Titulo;
        el.value = opt;
        select.appendChild(el);
    });
}

function iniciarCategoriaSelect(select) {
    getCategorias()
        .then(function (myJson) {
            adicionarCategoriaSelect(myJson, select);
        })
}

function iniciarNoticiaSelect(select) {
    getNoticias()
        .then(function (myJson) {
            adicionarNoticiasSelect(myJson, select);
        })
}

function iniciarNoticias() {
    getNoticia(1)
        .then(function (myJson) {
            adicionarNoticiaCapa(myJson);
            //return myJson;
        });
    getNoticias()
        .then(noticias => {

            for (let noticia of noticias) {
                adicionarNoticia(noticia);
            }
        });
    
}

document.addEventListener('DOMContentLoaded', function main(e) {
    iniciarNoticias();
    iniciarCategoriaSelect(document.querySelector("#adicionar-noticia").querySelector("[name=categoria]"));
    iniciarCategoriaSelect(document.querySelector("#alterar-noticia").querySelector("[name=categoria]"));
    iniciarNoticiaSelect(document.querySelector("#remover-noticia").querySelector("[name=categoria]"));
});



