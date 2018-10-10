class Bomb {
  constructor(x, y, r, t) {
    this.x = x || Math.floor(Math.random() * 800);
    this.y = y || 0;
    this.r = r || 25;
    this.t = t || 5;
    this.exploded = false;
  }

  Update() {
    if (Collide(this.x, this.y) || this.y > 600) {
      this.Explode();
      Object.seal(this);
    } else {
      this.y = Draw(this.x, this.y);
      setTimeout(this.Update.bind(this), 10);
    }
  }

  Explode(index) {
    this.exploded = true;
    Explode(this.x, this.y, this.r, this.t);
  }
}

// Restore the destroyed area over time
function Restore(x, y, radius, innerRad) {
  let unrestored = 0;
  let sqRad = (radius + 1) * (radius + 1);
  for (i = -radius; i <= radius; i++) {
    for (j = -radius; j <= radius; j++) {
      // if (i * i + j * j < sqRad) {
      if (i * i + j * j < sqRad && i * i + j * j >= innerRad * innerRad) {
        if (map.data[((x + i) + (y + j+4) * width) * depth - 1] == restoreData.data[((x + i) + (y + j) * width) * depth - 1]) {
          map.data[((x + i) + (y + j) * width) * depth - 1] = restoreData.data[((x + i) + (y + j) * width) * depth - 1];
        } else {
          unrestored++;
        }
      }
    }
  }
  innerRad--;
  if (innerRad == 0) {
    innerRad = radius;
  }
  if (unrestored > radius/2) {
    setTimeout(Restore.bind(null, x, y, radius, innerRad), 1000);
  }
  else {
    for (i = -radius; i <= radius; i++) {
      for (j = -radius; j <= radius; j++) {
            map.data[((x + i) + (y + j) * width) * depth - 1] = restoreData.data[((x + i) + (y + j) * width) * depth - 1];
      }
    }
    return;
  }
}

// Destroy all pixels within a given radius
function Explode(x, y, radius, timeOut) {
  let sqRad = (radius + 1) * (radius + 1);
  for (i = -radius; i <= radius; i++) {
    for (j = -radius; j <= radius; j++) {
      if (i * i + j * j < sqRad) {
        map.data[((x + i) + (y + j) * width) * depth - 1] = 0;
        CheckPlayerCollision(x + i, y + j);
      }
    }
  }
  setTimeout(Restore.bind(null, x, y, radius, radius-1), timeOut * 1000);
}

// Checks collision with the background
function Collide(x, y) {
  CheckPlayerCollision(x, y);
  return (map.data[(x + y * width) * depth - 1] != 0);
}

// Draws the falling bomb
function Draw(x, y) {
    y++;
    ctx2.fillStyle = "#333";
    ctx2.fillRect(x-1, y-2, 3, 3);
    setTimeout(Clear.bind(null, x, y), 10);
    return y;
}

// Clears the old bomb draw at the end of the frame
function Clear(x, y) {
  ctx2.clearRect(x-1, y-2, 3, 3);
}

function CheckPlayerCollision(x, y) {
  if (x >= P.x - 2 && x <= P.x + 2 && y >= P.y - 4 && y <= P.y) {
    ctx3.font = "80px Arial";
    ctx3.fillText("Game Over", 200, 300);
  }
}
