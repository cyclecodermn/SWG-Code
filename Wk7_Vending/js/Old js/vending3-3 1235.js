
$(document).ready(function() {

  $('#TotalDeposit').append('<center>xperi2</center>');  
  //ClearCells();
  GetItems();
  newAmount=0.0;
  UpdateTotal(newAmount);

  $('#Cell1Name').on('click',ActCell1);
  $('#Cell2Name').on('click',ActCell2);

  $('#AddDlrBtn').on('click',AddDollar);
  $('#AddQuarBtn').on('click',AddQuarter);
  $('#AddDimeBtn').on('click',AddDime);
  $('#AddNickBtn').on('click',AddNickel);

//  $('#ChangeRtrnBtn').on('click',ChangeRtrn);
//  $('#MkPurchaseBtn').on('click',MkPurchase);

var tbl = document.getElementById("vendingTable"); 
if (tbl != null) { 
    for (var i = 0; i < tbl.rows.length; i++) { 
        for (var j = 0; j < tbl.rows[i].cells.length; j++) 
            tbl.rows[i].cells[j].onclick = function () { getval(this.id); }; 
    } 
} 


 });

 function getval(cellID) { 
  var cellNum=cellID.substr(4,1)
  if (cellNum>0 && cellNum<10) { ShowSelection(cellNum); }
  
//cellNum=cellID;
 // alert(cellNum); 
} 


function ChangeRtrn()
{
  var amount='$'+GetCellValue("DepRow").toFixed(2);
  $('#ChangeBox').text('').append(amount);
  
  amount=0;
  var zeroTotal='$'+amount.toFixed(2);
  $('#TotalDeposit').text('').append(zeroTotal);
}

function AddDollar()
{
  //alert('Reached AddDollar');
  AddMoney(1);
}
function AddQuarter()
{
  AddMoney(0.25);
}

function AddDime()
{
  AddMoney(0.10);
}
function AddNickel()
{
  //var myVar=document.getElementById("vendingTable").rows[1];
  //alert(myVar);
  // alert(document.getElementById("vendingTable").rows[1].cells.namedItem("TotalDeposit").innerHTML);
  AddMoney(0.05);
}
 function AddMoney(addAmount)
 {
  var newTotal=GetCellValue("DepRow");
  
  var newTotal=newTotal+(addAmount.valueOf()*1);
  UpdateTotal(newTotal);
 }

function UpdateTotal(amount)
{
  newTotal='$'+amount.toFixed(2);
   //newTotal='$';
   //alert('Reached InitTotal function');
  $('#TotalDeposit').text('').append(newTotal);
}
/////////////////////////////////////////////
////////// Helper Functions ////////////////

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
      for (i=1;i<=10;i++)
      {
      var nameCell='#Cell'+i+'Name';
      var costCell='#Cell'+i+'Cost';
      var quantCell='#Cell'+i+'Quant';
      

      var cellID=data[i-1].id+"<br />";
      var nameInfo=data[i-1].name+"<br />";
      var costInfo=data[i-1].price.valueOf().toFixed(2);
      var quantInfo="Qunatity Left: "+data[i-1].quantity+"<br />";
      
      nameInfo=cellID+'<center>'+nameInfo+'</center>';
      costInfo='<center>$'+costInfo+'</center>';
      quantInfo='<center>'+quantInfo+'</center>';

      $(nameCell).text('').append(nameInfo)+'<p>';
      $(costCell).text('').append(costInfo)+'<p>';
      $(quantCell).text('').append(quantInfo)+'<p>';
    }   
    },
  
   });
 
 }

function ClearCells()
{
  for (i=1;i<=9;i++)
  {
    crntCell='#Cell'+i+'Name';
    newStuff='Cell'+i;
    $(crntCell).text('').append(newStuff);
  }
}
 
 function ActCell1()
 {
  ShowSelection(1)
 }

 function ActCell2()
 {
  ShowSelection(2)
}

function ShowSelection(cellNum)
{
 //var itemID=cellNum+""
 $('#IDMsgBox').text('Item# ').append(cellNum); 

  var costID='Cell'+cellNum+'Cost';
  itemCost=document.getElementById(costID).innerHTML;
  $('#ItemCostBox').text('').append(itemCost);
}


function GetCellValue(rowName)
{
//   var Row = document.getElementById(rowName);
//   var Cells = Row.getElementsByTagName("#TotalDeposit");
//   var Cells = Row.amount.cellID("#TotalDeposit");
// alert(Cells);

var strTotal=document.getElementById("TotalDeposit").innerHTML;

//  var strTotal=document.getElementById("vendingTable").rows[1].cells.namedItem("TotalDeposit").innerHTML;
  var decTotal=strTotal.substr(1,strTotal.length-1).valueOf()*1;
  //var newTotal1=decTotal1+(addAmount.valueOf()*1);
  return decTotal;
}


