if time <= 0
{
    seconds++;
    playerScore -= 5;
    time = room_speed;
}
time--;

if playerScore <= 0
{
    room_restart();
}
if seconds >= 60
{
    seconds = 0;
    minutes++;
}
if minutes >= 60
{
    minutes = 0;
    hours++;
}
