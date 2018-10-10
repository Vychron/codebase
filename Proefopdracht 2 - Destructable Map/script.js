const cvs1 = document.getElementById("canvas1");
const cvs2 = document.getElementById("canvas2");
const cvs3 = document.getElementById("canvas3");
const ctx1 = cvs1.getContext("2d");
const ctx2 = cvs2.getContext("2d");
const ctx3 = cvs3.getContext("2d");
const height = cvs1.height;
const width = cvs1.width;
const depth = 4;

var P;
var targetFPS = 30;
var bombTimer = 0;
var bombTimerMax = 3;

var back = new Image();
var map, restoreData;
back.src = "level.png";

function SpawnBomb(x, y, r, t) {
  B = new Bomb(x, y, r, t);
  B.Update();
  if (bombTimerMax > targetFPS/2){
    bombTimerMax --;
  }
}

/// Set up the level for the first time
function Setup() {
  let current = 0;
  map = ctx1.getImageData(0, 0, 800, 600);
  restoreData = ctx1.getImageData(0, 0, 800, 600);
  ctx1.putImageData(map, 0, 0);
  bombTimerMax = bombTimerMax * targetFPS;
  P = new Player(400, 300);
  setTimeout(Loop, 1000/targetFPS);
}

function Loop() {
  ctx1.putImageData(map, 0, 0);
  bombTimer++;
  if (bombTimer >= bombTimerMax){
    SpawnBomb(null, 0, 30, 5);
    bombTimer = 0;
  }
  P.Update();
  P.Draw();
  setTimeout(Loop, 1000/targetFPS);
}

cvs1.style.background = "url(back.png)";

back.onload = function() {
  ctx1.drawImage(back, 0, 0);
  Setup();
};

// cvs2.addEventListener("click", (e)=>{
//   let rect = cvs2.getBoundingClientRect();
//   SpawnBomb(e.clientX - rect.left, e.clientY - rect.top, 30, 5);
// });

window.addEventListener("keydown", (e)=>{
    if (e.key == "a") {P.direction = -1;}
    if (e.key == "d") {P.direction = 1;}
});

window.addEventListener("keyup", (e)=>{
    if (e.key == "a") {P.direction = 0;}
    if (e.key == "d") {P.direction = 0;}
});

window.addEventListener("keypress", (e)=>{
  if (e.key == "w") {P.Jump();}
})
