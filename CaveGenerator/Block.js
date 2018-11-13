class Block
{
  constructor(x, y, w, c, label)
  {
    this.x = x || Math.random(780) + 10;
    this.y = y || Math.random(430) + 10;
    this.w = w || 20;
    this.colour = c || "#000000";
    this.label = label || "";
    this.actives = [true,true,true,true,true,true,true,true,true];
    this.density = 0;
  }
  draw()
  {
    this.density = 0;
    context.fillStyle = this.colour;
    context.clearRect(this.x, this.y, this.x + this.w, this.y + this.w);
    context.beginPath();
    if (this.actives[0])
    {
      context.fillRect  (this.x, this.y, this.w/4, this.w/4);
      context.strokeRect(this.x, this.y, this.w/4, this.w/4);
      this.density++;
    }
    if (this.actives[1])
    {
      context.fillRect  (this.x + this.w/4, this.y, this.w/2, this.w/4);
      context.strokeRect(this.x + this.w/4, this.y, this.w/2, this.w/4);
      this.density += 2;
    }
    if (this.actives[2])
    {
      context.fillRect  (this.x + 3*this.w/4, this.y, this.w/4, this.w/4);
      context.strokeRect(this.x + 3*this.w/4, this.y, this.w/4, this.w/4);
      this.density++;
    }
    if (this.actives[3])
    {
      context.fillRect  (this.x, this.y + this.w/4, this.w/4, this.w/2);
      context.strokeRect(this.x, this.y + this.w/4, this.w/4, this.w/2);
      this.density += 2;
    }
    if (this.actives[4])
    {
      context.fillRect  (this.x + this.w/4, this.y + this.w/4, this.w/2, this.w/2);
      context.strokeRect(this.x + this.w/4, this.y + this.w/4, this.w/2, this.w/2);
      this.density += 4;
    }
    if (this.actives[5])
    {
      context.fillRect  (this.x + 3*this.w/4, this.y + this.w/4, this.w/4, this.w/2);
      context.strokeRect(this.x + 3*this.w/4, this.y + this.w/4, this.w/4, this.w/2);
      this.density += 2;
    }
    if (this.actives[6])
    {
      context.fillRect  (this.x, this.y + 3*this.w/4, this.w/4, this.w/4);
      context.strokeRect(this.x, this.y + 3*this.w/4, this.w/4, this.w/4);
      this.density++;
    }
    if (this.actives[7])
    {
      context.fillRect  (this.x + this.w/4, this.y + 3*this.w/4, this.w/2, this.w/4);
      context.strokeRect(this.x + this.w/4, this.y + 3*this.w/4, this.w/2, this.w/4);
      this.density += 2;
    }
    if (this.actives[8])
    {
      context.fillRect  (this.x + 3*this.w/4, this.y + 3*this.w/4, this.w/4, this.w/4);
      context.strokeRect(this.x + 3*this.w/4, this.y + 3*this.w/4, this.w/4, this.w/4);
      this.density++;
    }
    context.fillStyle = this.colour;
    context.fill();
    context.closePath();
  }
  drag()
  {
    let drag = false;
    let xMouse, yMouse, dx, dy, distance;

    canvas.addEventListener('mousedown', (evt)=>
    {
      let rect = canvas.getBoundingClientRect();
      xMouse = evt.clientX - rect.left;
      yMouse = evt.clientY - rect.top;
      dx = xMouse - this.x;
      dy = yMouse - this.y;
      distance = Math.sqrt(dx * dx + dy * dy);
      if (distance <= this.r)
      {
        drag = true;
      }
      else
      {
        drag = false;
      }
    });
    canvas.addEventListener('mouseup',(evt)=>
    {
      drag = false;
    });
    canvas.addEventListener('mousemove',(evt)=>
    {
      if (drag)
      {
        let rect = canvas.getBoundingClientRect();
        xMouse = evt.clientX - rect.left;
        yMouse = evt.clientY - rect.top;
        dx = xMouse - this.x;
        dy = yMouse - this.y;
        this.x = xMouse;
        this.y = yMouse;
      }
    });
  }

  ToMiddle(line1, line2)
  {
    let tempX = -(line2.yIntercept - line1.yIntercept) / (line1.slope - line2.slope);
    this.y = -line1.slope * tempX + line1.yIntercept;
    this.x = 800 - tempX;
  }

  distance(point)
  {
    let dx, dy;
    dx = point.x - this.x;
    dy = point.y - this.y;
    return Math.sqrt(Math.pow(dx, 2) + Math.pow(dy, 2));
  }
}
