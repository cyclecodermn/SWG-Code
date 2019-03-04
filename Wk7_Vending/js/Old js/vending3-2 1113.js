
$(document).ready(function() {

  
ClearCells();
GetItems();
  $('#Cell1').on('click',ActCellOne);
  $('#Cell2').on('click',ActCellTwo);
 });
 

 function GetItems()
 {
   var getItemsURL= 'http://localhost:8080/items';
   //alert('Reached success function');
   //$('#change').text('Wind Speed: ')   
   $.ajax({
     type: 'GET',
     url: getItemsURL,
     
     success: function (data,status) 
     {
      $('#change').text('').append(data[0].name)+'<p>';
      $('#change').append(data[1].name)+'<p>';
      $('#change').append(data[2].name);
    },
 
 
   });
 
 }

function ClearCells()
{
  for (i=1;i<=9;i++)
  {
    crntCell='#Cell'+i;
    newStuff='Cell'+i;
    $(crntCell).text('').append(newStuff);
  }
}
 
 function ActCellOne(event)
 {
  // alert('Cell01');
  $('#Cell1').text('').append('<center>xperi2</center>');
 }

 function ActCellTwo(event)
 {
  // alert('Cell02');
  $('#Cell2').append('<center>xperi2</center>');
}