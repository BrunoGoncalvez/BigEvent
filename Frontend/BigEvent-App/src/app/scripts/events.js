
// endpoint start
function initStyle(){

  this.centerTableData();

}


// Style functions
function centerTableData(){
  let table_tds = document.querySelectorAll("tbody > tr > td");

  table_tds.forEach(element => {
    element.classList.add("align-middle");
  })
}
