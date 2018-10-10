class Player {
  constructor(x, y) {
    this.x = 400 || x;
    this.y = 300 || y;
    this.xPrev = 0;
    this.yPrev = 0;
    this.pull = 3;
    this.obstructed = false;
    this.direction = 0;
  }

  Update() {
    if (!this.PlayerCollide(this.x, this.y)) {
      this.y += this.pull;
    }
    if (this.pull < 3) {
      this.pull++;
    }
    if (!this.obstructed) {
      this.x += this.direction * 3;
    }
    if (this.x > width) {
      this.x = 0;
    }
    if (this.x < 0) {
      this.x = 800;
    }
    if (this.y > 600) {
      ctx3.font = "80px Arial";
      ctx3.fillText("Game Over", 200, 300);
    }
  }

  PlayerCollide(x, y) {
    for (let i = -2; i <= 2; i++) {
      if (map.data[((x+ i) + (y - 1) * width) * depth - 1] != 0) {
        this.y--;
        this.pull = 0;
        this.obstructed = true;
        return true;
      }
      else if (map.data[((x+ i) + (y + 1) * width) * depth - 1] != 0) {
        this.obstructed = false;
        return true;
      }
    }
  }

  Jump() {
    if (this.PlayerCollide(this.x, this.y)) {
      this.pull = -10;
      this.y += this.pull;
    }
  }

  Draw() {
    ctx2.fillStyle = "#ff0000";
    ctx2.clearRect(this.xPrev-2, this.yPrev-4, 5, 5);
    ctx2.fillRect(this.x-2, this.y-4, 5, 5);
    this.xPrev = this.x;
    this.yPrev = this.y;
  }
}
