
function categories(data) {
    var rootnoticias = document.querySelector("#root-noticias");

    rootnoticias.innerHTML = "";

    let divcontainer = createNode("div");
    divcontainer.className = "container";
    append(rootnoticias, divcontainer);

    let h1my4 = createNode("h1");
    h1my4.className = "my-4";
    h1my4.innerText = "Noticias ";

    let small = createNode("small");
    small.innerHTML = "Selecione uma Noticia";
    append(h1my4, small);
    append(divcontainer, h1my4);

    let buttonAdd = createNode("button");
    buttonAdd.innerHTML = "Adicionar uma Noticia";
    

    data.forEach(function (categorie) {
        let div = createNode('div'), 
            divcol = createNode('div'), 
            a = createNode('a'), 
            img = createNode('img'), 
            divcoldesc = createNode('div'), 
            h3 = createNode('h3'),
            p = createNode('p'), 
            acat = createNode('a');

        // Declaracao das classes e atributos especificos
        div.className = "row";
        divcol.className = "col-md-7";
        img.className = "img-fluid rounded mb-3 mb-md-0"
        img.src = "/Images/" + `${categorie.Imagens[0].Directorio}`;
        img.width = 700;
        img.height = 300;
        divcoldesc.className = "col-md-5";
        h3.innerHTML = `${categorie.Titulo}`;
        p.innerHTML = `${categorie.Resumo}`;
        acat.className = "btn btn-primary";
        acat.innerHTML = `${categorie.Titulo}`;

        acat.addEventListener('click', function () {
            onClickNot(categorie.NoticiasID);
        });

        // Devidas alocacoes appends
        append(a, img);
        append(divcol, a);
        append(div, divcol);
        append(divcoldesc, h3);
        append(divcoldesc, p);
        append(divcoldesc, acat);
        append(div, divcoldesc);
        append(divcontainer, div);
    })

    append(divcontainer, buttonAdd);

    buttonAdd.addEventListener("click", function () {
        adicionarNoticia();
    });
}

function onClickNot(id) {

    sessionStorage.not = id;

    getNoticia(id)
        .then(function (data) {
            noticia(data);
        })
        .catch(function (error) {
            console.log(error);
        });
}

function noticia(data) {

    var rootnoticias = document.querySelector("#root-noticias");

    rootnoticias.innerHTML = "";

    // Cabeçalho da noticia
    let div = createNode("div"),
        h1my4 = createNode("h1"),
        small = createNode("small"),
        divrow = createNode("div"),
        divcolmd8 = createNode("div"),
        imgfluid = createNode("img"),
        divcolmd4 = createNode("div"),
        h3my3 = createNode("h3"),
        p = createNode("p"),
        button = createNode("button");

    div.className = "container";
    h1my4.className = "my-4";
    h1my4.innerText = `${data.Titulo}`;
    small.innerText = `${data.Resumo}`;
    divrow.className = "row";
    divcolmd8.className = "col-md-8";
    imgfluid.className = "img-fluid";
    imgfluid.src = "/Images/" + `${data.Imagens[0].Directorio}`;
    divcolmd4.className = "col-md-4";
    h3my3.className = "my-3";
    h3my3.innerText = `${data.Data}`;
    p.innerText = `${data.Texto}`;
    button.innerText = "Editar Noticia ou Remover";

    button.addEventListener("click", function () {
        editarOuRemover(sessionStorage.id);
    });

    append(rootnoticias, div);
    append(div, h1my4);
    append(div, small);
    append(div, divrow);
    append(divrow, divcolmd8);
    append(divcolmd8, imgfluid);
    append(divrow, divcolmd4);
    append(divrow, h3my3);
    append(divrow, p);
    append(divrow, button);
}

function editarOuRemover(id) {
    let rootnoticias = document.querySelector("#root-noticias");

    let formIdent = rootnoticias.querySelector("#alterar-noticia");

    if (formIdent == null) {

        // Peças para formulario de alteracao de uma noticia
        let form = createNode("form"),
            divformgroup = createNode("div"),
            labelTitulo = createNode("label"),
            inputTitutlo = createNode("input"),
            labelResumo = createNode("label"),
            inputResumo = createNode("input"),
            labelTexto = createNode("label"),
            inputTexto = createNode("input"),
            labelCategoria = createNode("label"),
            selectCategoria = createNode("select"),
            buttonSubAlt = createNode("button");


        form.id = "alterar-noticia";
        divformgroup.className = "form-group";
        labelTitulo.innerText = "Titulo";
        inputTitutlo.name = "titulo";
        labelTexto.innerText = "Texto";
        inputTexto.name = "texto";
        labelResumo.innerText = "Resumo";
        inputResumo.name = "resumo";
        labelCategoria.innerText = "CategoriaFK";
        selectCategoria.name = "categoria";
        buttonSubAlt.innerText = "Alterar Noticia";
        buttonSubAlt.className = "btn btn-primary";
        buttonSubAlt.type = "submit";


        append(rootnoticias, form);
        append(form, divformgroup);
        append(divformgroup, labelTitulo);
        append(divformgroup, inputTitutlo);
        append(divformgroup, labelResumo);
        append(divformgroup, inputResumo);
        append(divformgroup, labelTexto);
        append(divformgroup, inputTexto);
        append(divformgroup, labelCategoria);
        append(divformgroup, selectCategoria);
        append(divformgroup, buttonSubAlt);

        let formRem = createNode("form"),
            divRem = createNode("div"),
            labelRem = createNode("label"),
            selectCatRem = createNode("select"),
            buttonRem = createNode("button");

        formRem.id = "remover-noticia";
        divRem.className = "form-group";
        labelRem.className = "control-label";
        labelRem.innerText = "Titulos";
        selectCatRem.name = "categoria";
        buttonRem.type = "submit";
        buttonRem.innerText = "Remover Noticia";
        buttonRem.className = "btn btn-primary";

        append(rootnoticias, formRem);
        append(formRem, divRem);
        append(formRem, labelRem);
        append(formRem, selectCatRem);
        append(formRem, buttonRem);
        

        iniciarCategoriaSelect(document.querySelector("#alterar-noticia").querySelector("[name=categoria]"));

        iniciarNoticiaSelect(document.querySelector("#remover-noticia").querySelector("[name=categoria]"));

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

            NoticiaID = sessionStorage.not;

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
                //.then(novaNoticia => adicionarNoticia(noticia))
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
    }
}

function adicionarNoticia() {
    var rootnoticias = document.querySelector("#root-noticias");

    rootnoticias.innerHTML = "";

    let form = createNode("form"),
        div = createNode("div"),
        labelTitulo = createNode("label"),
        inputTitulo = createNode("input"),
        labelResumo = createNode("label"),
        inputResumo = createNode("input"),
        labelTexto = createNode("label"),
        inputTexto = createNode("input"),
        labelCategoria = createNode("label"),
        inputCategoria = createNode("select"),
        buttonAdd = createNode("button");

    form.id = "adicionar-noticia";
    div.className = "form-group";
    labelTitulo.innerText = "Titulo";
    labelTitulo.className = "control-label";
    inputTitulo.className = "form-control";
    inputTitulo.name = "titulo";
    labelResumo.innerText = "Resumo";
    labelResumo.className = "control-label";
    inputResumo.className = "form-control";
    inputResumo.name = "resumo";
    labelTexto.innerText = "Texto";
    labelTexto.className = "control-label";
    inputTexto.className = "form-control";
    inputTexto.name = "texto";
    labelCategoria.innerText = "CategoriaFK";
    labelCategoria.className = "control-label";
    inputCategoria.className = "form-control";
    inputCategoria.name = "categoria";
    buttonAdd.className = "btn btn-primary";
    buttonAdd.type = "submit";
    buttonAdd.innerText = "Adicionar Noticia";

    

    append(rootnoticias, form);
    append(form, div);
    append(div, labelTitulo);
    append(div, inputTitulo);
    append(div, labelResumo);
    append(div, inputResumo);
    append(div, labelTexto);
    append(div, inputTexto);
    append(div, labelCategoria);
    append(div, inputCategoria);
    append(div, buttonAdd);

    iniciarCategoriaSelect(document.querySelector("#adicionar-noticia").querySelector("[name=categoria]"));

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



