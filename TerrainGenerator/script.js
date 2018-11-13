const canvas = document.getElementById("canvas");
const context = canvas.getContext("2d");
const button = document.getElementById("button");
const amplifier = document.getElementById("amplifier");
const content = document.getElementById("content");
let pixels = [[]];
let pixs;
let data;
let newData;
let data3D, tempData3D;
let imgX = 16, imgY = 16, imgZ = 4;
let val;
let cur;
let smoothCounter = 5;
let currentCounter = 0;

button.addEventListener('click', ()=>
{
  //context.fillRect(0, 0, 160, 160);
  data = context.getImageData(0, 0, imgX, imgY);
  amp = amplifier.value;
  if (amp > 255) amp = 255;
  if (amp < 0) amp = 0;
  data3D = new Array(imgX);
  Init();
});

function Init()
{

  for (let i = 0; i < imgX; i++) {
    data3D[i] = new Array(imgY);
    for (let j = 0; j < imgY; j++) {
      data3D[i][j] = new Array(imgZ);
      for (let k = 0; k < imgZ; k++) {
        data.data[(i + j * imgY) * imgZ - 4 + k] = Math.random() * 255;
        data3D[i][j][k] = data.data[(i + j * imgY) * imgZ - 4 + k];
      }
    }
  }
  context.putImageData(data, 0, 0);
  Smoothen(900);

}

function Smoothen(times) {
  tempData3D = data3D;
  for (let i = 0; i < imgX; i++) {
    for (let j = 0; j < imgY; j++) {
      for (let k = 0; k < imgZ; k++) {
        SmoothPixel(i, j, k);
      }
    }
  }
  data3D = tempData3D;
  PutData(data3D);
  if (times > 0) {
    Smoothen(times-1);
  }
  else {
    console.log(data.data);
  }
}

function SmoothPixel(x, y, z) {
  let avg = 0;
  let pixCount = 0;
  for (let i = -1; i < 2; i++) {
    for (let j = -1; j < 2; j++) {
      if (x + i >= 0 && x + i < imgX && y + j >= 0 && y + j < imgY) {
        avg += data3D[x + i][y + j][z];
        pixCount++;
      }
    }
  }
  //console.log(tempData3D[x][y][z]);
  tempData3D[x][y][z] = Math.round(avg / pixCount);
}

function PutData(dataArr) {
  let posCount = 0;
  for (let i = 0; i < imgX; i++) {
    for (let j = 0; j < imgY; j++) {
      for (let k = 0; k < imgZ; k++) {
        dataArr[i][j][k] = data.data[posCount];
        posCount++;
      }
    }
  }
  context.putImageData(data, 0, 0);
  console.log("done");

}


  // for (let i = 0; i < Math.floor(Math.random() * 10); i++)
  // {
  //   context.beginPath();
  //   context.fillStyle = "rgba(255,255,255,100)";
  //   context.strokeStyle = "rgba(255,255,255,100)";
  //   context.arc (Math.floor(Math.random() * 160), Math.floor(Math.random() * 160), Math.floor(Math.random() * 15), 0, 2*Math.PI);
  //   context.fill();
  //   context.closePath();
  // }

  //   newData = data;
  //   for (let i = 0; i < data.data.length/4; i += 4)
  //   {
  //     //newData[i] = 255;
  //   }
  //   setTimeout(NextLayer, 10);
  // }
  //
  // function NextLayer()
  // {
  //   cur = 0;
  //   for (let i = 0; i < data.data.length; i += 4)
  //       Smoothen(i);
  //   data = newData;
  //   context.putImageData(data, 0, 0);
  //   if (smoothCounter > currentCounter)
  //   {
  //     currentCounter++;
  //     setTimeout(NextLayer, 10);
  //   }
  //   else
  //   {
  //     currentCounter = 0;
  //     StartTHREE();
  //     document.getElementById("img").src = canvas.toDataURL("image/png");
  //   }
  // }
  //
  // function Smoothen(num)
  // {
  //   cur = num - 644;
  //   pixs = 0;
  //   val = 0;
  //   for (let i = 0; i < 3; i++)
  //   {
  //     for (let j = 0; j < 3; j++)
  //     {
  //       if (data.data[cur] != undefined)
  //       {
  //         pixs += data.data[cur];
  //         val++;
  //       }
  //       cur += 4;
  //     }
  //     cur += 628;
  //   }
  //   c = Math.floor(pixs/val);
  //   newData.data[num] = c;
  //   newData.data[num+1] = c;
  //   newData.data[num+2] = c;
  // }

let width = window.innerWidth * 0.98;
let height = window.innerHeight * 0.5;
let scene;
let rend = new THREE.WebGLRenderer();
rend.setSize(width, height);
let camera = new THREE.PerspectiveCamera(45, width/height, 1, 1000);
camera.position.z = 270;
camera.position.y = 180;
camera.up = new THREE.Vector3(0, 1, 0);
camera.lookAt(new THREE.Vector3(0, 30, 0));
let material;
let geometry;
let mesh;
let noiseData;
let heights = [];
let currentHeight;
let light;

function StartTHREE()
{
  noiseData = context.getImageData(0, 0, 160, 160);
  for (let i = 0; i < noiseData.data.length; i+= 4)
  {
    heights[i/4] = Math.round(noiseData.data[i]/255 * amp);
  }
  content.appendChild(rend.domElement);
  light = new THREE.PointLight( 0xffcc00, 2, 1000000);
  scene = new THREE.Scene();
  scene.add(light);
  light.position.y = 200;
  material = new THREE.MeshToonMaterial({color: 0x999999});
  geometry = new THREE.CubeGeometry(1, 15, 1);
  currentHeight = 0;
  for (let i = 0; i < 160; i++)
  {
    for (let j = 0; j < 160; j++)
    {
      mesh = new THREE.Mesh(geometry, material);
      scene.add(mesh);
      mesh.position.x = j-80;
      mesh.position.y = heights[currentHeight]-55;
      mesh.position.z = i-80;
      currentHeight++;
    }
  }
  rend.render(scene, camera);
}
