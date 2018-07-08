function categories(data) {
    var rootnoticias = document.querySelector("#root-noticias");

    rootnoticias.innerHTML = "";

    let divcontainer = createNode("div");
    divcontainer.className = "container";
    append(root, divcontainer);

    let h1my4 = createNode("h1");
    h1my4.className = "my-4";
    h1my4.innerText = "Noticias";

    let small = createNode("small");
    small.innerHTML = "Selecione uma Noticia";
    append(h1my4, small);
    append(divcontainer, h1my4);
}

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

function divCategoria(categoria) {
    let template = document.querySelector('#template-capa').cloneNode(true);
    template.removeAttribute('id');

    let titulo = template.querySelector('h2');
    titutlo.innerHTML = categoria.Nome;

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

function adicionarCategoria(categoria) {
    let template = divCategoria(categoria);

    let grelha = document.querySelector('#root-categorias');

    grelha.appendChild(template);
}

function adicionarCategoriaSelect(categorias, select) {
    //console.log(categorias.length);

    categorias.forEach(function (catg) {
        let opt = catg.CategoriaID;
        let el = document.createElement("option");
        el.textContent = catg.Nome;
        el.value = opt;
        append(select, el);
    });
}

function adicionarNoticiasSelect(noticias, select) {
    noticias.forEach(function (catg) {
        let opt = catg.NoticiasID;
        let el = document.createElement("option");
        el.textContent = catg.Titulo;
        el.value = opt;
        append(select, el);
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

function iniciarCategorias() {
    getCategorias()
        .then(categorias => {
            for (let categoria of categorias) {
                adicionarCategoria();
            }
        });
}

function iniciarJornalistas() { }

function iniciarImagens() { }

function createNode(element) {
    return document.createElement(element);
}

function append(parent, el) {
    return parent.appendChild(el);
}

document.addEventListener('DOMContentLoaded', function main(e) {
    //iniciarNoticias();
    //iniciarCategoriaSelect(document.querySelector("#adicionar-noticia").querySelector("[name=categoria]"));
    //iniciarCategoriaSelect(document.querySelector("#alterar-noticia").querySelector("[name=categoria]"));
    //iniciarNoticiaSelect(document.querySelector("#remover-noticia").querySelector("[name=categoria]"));
});



