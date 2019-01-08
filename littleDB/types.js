const type1 = document.getElementById("type1");
const type2 = document.getElementById("type2");
const TYPES = [
  "Fire",
  "Water",
  "Electric",
  "Grass",
  "Ice",
  "Fighting",
  "Poison",
  "Ground",
  "Flying",
  "Psychic",
  "Bug",
  "Rock",
  "Ghost",
  "Dragon",
  "Dark",
  "Steel",
  "Fairy"
];

setTypes(type1);
setTypes(type2);

function setTypes(t) {
  let types = TYPES;
  if (t == type2) {
    types.push("Normal");
  }
  types.sort();
  for (let i = 0; i < types.length; i++) {
    let opt = document.createElement("option");
    opt.text = types[i];
    opt.value = types[i];
    t.appendChild(opt);
  }
}
