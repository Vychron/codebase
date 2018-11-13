const canvas = document.getElementById("canvas");
const context = canvas.getContext("2d");
const button = document.getElementById("button");
const dense = document.getElementById("density")
const estDense = document.getElementById("estDense");

let blocks = [];
let size;
let density;
let a;
let interval

button.addEventListener('click', ()=>
{
  Init();
});

Init();

function Init()
{
  size = document.getElementById("size").value;
  density = estDense.value;
  if (size > 50)
    size = 50;
  else if (size < 10)
    size = 10;
  for (let i = 0; i < size; i++)
  {
    for (let j = 0; j < size; j++)
    {
      a = new Block(800/size * i + 1, 800/size * j + 1, (800/size)-1, '#555', i + "," + j);
      blocks[[i,j]] = a;
    }
  }
  Step2();
}

function Step2()
{
  for (let i = 0; i < size; i++)
  {
    for (let j = 0; j < size; j++)
    {
      a = blocks[[i,j]];
      if (Math.random() > (density / 100 + 0.175*(9/density)+0.1))
      {
        a.actives[4] = false;
      }
      a.draw();
    }
  }
  setTimeout(Step3, 500);
}

function Step3()
{
  for (let i = 0; i < size; i++)
  {
    for (let j = 0; j < size; j++)
    {
      a = blocks[[i,j]];
        a.actives[1] = a.actives[4];
        a.actives[3] = a.actives[4];
        a.actives[5] = a.actives[4];
        a.actives[7] = a.actives[4];
      a.draw();
    }
  }
  setTimeout(Step4, 500);
}

function Step4()
{
  let reInit = false;
  for (let i = 0; i < size; i++)
  {
    for (let j = 0; j < size; j++)
    {
      a = blocks[[i,j]];
      if (blocks[[i-1,j]] != undefined) a.left = blocks[[i-1,j]].actives[4];
      else a.left = false;
      if (blocks[[i+1,j]] != undefined) a.right = blocks[[i+1,j]].actives[4];
      else a.right = false;
      if (blocks[[i,j-1]] != undefined) a.up = blocks[[i,j-1]].actives[4];
      else a.up = false;
      if (blocks[[i,j+1]] != undefined) a.down = blocks[[i,j+1]].actives[4];
      else a.down = false;
      if (!a.up && !a.down && !a.left && !a.right && a.actives[4])
      {
        a.actives[4] = false;
        reInit = true;
      }
      if (a.up && a.down && a.left && a.right && !a.actives[4])
      {
        a.actives[4] = true;
        reInit = true;
      }
      a.draw();
    }
  }
  if (reInit) setTimeout(Step3, 500);
  else setTimeout(Step5, 500);
}

function Step5()
{
  for (let i = 0; i < size; i++)
  {
    for (let j = 0; j < size; j++)
    {
      a = blocks[[i,j]];
      if (!a.left)
      a.actives[3] = false;
      if (!a.right)
      a.actives[5] = false;
      if (!a.up)
      a.actives[1] = false;
      if (!a.down)
      a.actives[7] = false;
      a.draw();
    }
  }
  setTimeout(Step6, 500);
}

function Step6()
{
  for (let i = 0; i < size; i++)
  {
    for (let j = 0; j < size; j++)
    {
      a = blocks[[i,j]];
      if (blocks[[i-1,j]] == undefined && a.actives[4]) a.actives[3] = true;
      if (blocks[[i+1,j]] == undefined && a.actives[4]) a.actives[5] = true;
      if (blocks[[i,j-1]] == undefined && a.actives[4]) a.actives[1] = true;
      if (blocks[[i,j+1]] == undefined && a.actives[4]) a.actives[7] = true;
      a.draw();
    }
  }
  setTimeout(Step7, 500)
}

function Step7()
{
  let b = 0;
  for (let i = 0; i < size; i++)
  {
    for (let j = 0; j < size; j++)
    {
      a = blocks[[i,j]];
      if (a.actives[1] && a.actives[3]) a.actives[0] = true;
      else a.actives[0] = false;
      if (a.actives[1] && a.actives[5]) a.actives[2] = true;
      else a.actives[2] = false;
      if (a.actives[3] && a.actives[7]) a.actives[6] = true;
      else a.actives[6] = false;
      if (a.actives[5] && a.actives[7]) a.actives[8] = true;
      else a.actives[8] = false;
      a.draw();
      b += a.density;
      dense.innerHTML = Math.round((b / 16 * 10000) / (size*size)) / 100 + "%";
    }
  }
  //setTimeout(Step7, 500)
}
