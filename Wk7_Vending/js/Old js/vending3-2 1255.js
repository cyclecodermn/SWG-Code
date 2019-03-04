
$(document).ready(function() {

  
//ClearCells();
GetItems();
newAmount=0.00;
InitializeTotal(newAmount);
  $('#Cell1').on('click',ActCell1);
  $('#Cell2').on('click',ActCell2);
 });
 
function InitializeTotal(amount)
{

  newTotal='$'+amount.toFixed(2)
   //newTotal='$';
  $('#Total').text('').append(newTotal);
}


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
      for (i=0;i<=9;i++)
      {
      var cellNum='#Cell'+i;

      cellInfo=data[i].name+"<br />";
      cellInfo+="$"+data[i].price+"<br />"+"<br />";
      cellInfo+="Qunatity Left: "+data[i].quantity+"<br />";
      
      cellInfo='<center>'+cellInfo;
      cellInfo+="<center />"
      cellID=i+1;
      cellInfo=cellID+cellInfo+"<br />";
      $(cellNum).text('').append(cellInfo)+'<p>';

    }   
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
 
 function ActCell1(event)
 {
  // alert('Cell01');
  $('#Cell1').text('').append('<center>xperi2</center>');
 }

 function ActCell2(event)
 {
  // alert('Cell02');
  $('#Cell2').append('<center>xperi2</center>');
}