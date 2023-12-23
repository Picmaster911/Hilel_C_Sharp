function getTime(){
  let date = new Date();
  console.log(date.getHours());
  alert(`${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`);
}
