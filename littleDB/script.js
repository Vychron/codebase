const addNew = document.getElementById("add-new");
const evos = document.getElementById("evolutions");
const saveBtn = document.getElementById("save");

var evoCount = 0;

addNew.addEventListener('click', ()=>{
  evoCount++;
  let field = document.createElement('fieldset');
  field.id = "evo" + evoCount;
  let tab = document.createElement('table');
  let tr = document.createElement('tr');
  let td = document.createElement('td');
  td.innerHTML = "<h3>Name</h3>";
  tr.appendChild(td);
  td = document.createElement('td');
  td.innerHTML = "<h3>Method</h3>";
  tr.appendChild(td);
  tab.appendChild(tr);
  tr = document.createElement('tr');
  td = document.createElement('td');
  let name = document.createElement('select');
  td.appendChild(name);
  tr.appendChild(td);
  td = document.createElement('td');
  let method = document.createElement('select');
  td.appendChild(method);
  tr.appendChild(td);
  tab.appendChild(tr);
  field.appendChild(tab);

    setNames(name);
    setMethods(method);

  let del = document.createElement('button');
  del.classList.add("del-evo");
  del.type = "button";
  del.innerHTML = "X";
  del.addEventListener('click', ()=>{
    del.parentNode.parentNode.removeChild(del.parentNode);
  });
    field.appendChild(del);
  evos.appendChild(field);
  evoCount--;
});

function setMethods(el) {

}
function setNames(el) {

}
