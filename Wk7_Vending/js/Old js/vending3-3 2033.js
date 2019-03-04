
$(document).ready(function() {

    InitializeTable();

    // $('#Cell1Name').on('click',ActCell1);
    // $('#Cell2Name').on('click',ActCell2);

    $('#AddDlrBtn').on('click',AddDollar);
    $('#AddQuarBtn').on('click',AddQuarter);
    $('#AddDimeBtn').on('click',AddDime);
    $('#AddNickBtn').on('click',AddNickel);

    $('#ChangeRtrnBtn').on('click',ChangeRtrn);
    $('#MakePrchsBtn').on('click',CkPurchase);

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
function CkPurchase()
{
  var purchasePrice=document.getElementById("ItemCostBox").innerHTML;
  var crntDeposit = document.getElementById("TotalDeposit").innerHTML; 
  //alert("X"+purchasePrice+"X");

//if (purchasePrice=="$0.00") 
{ 
  $('#Message').text('Please choose an item.'); }

  //var myVar=purchasePrice +', '+crntDeposit;

  //alert(myVar);
}

function MkPurchase()
{  
    var vendItemURL= 'http://localhost:8080/money/';
    var itemNum=document.getElementById("ItemNum").innerHTML;
    itemNum=itemNum.substr(itemNum.length-1,1);
    var depAmt=document.getElementById("TotalDeposit").innerHTML;
    depAmt=depAmt.substr(1,depAmt.length-1);
    vendItemURL+=depAmt+'/'+ 'item/'+itemNum;
   $('#Message').text(vendItemURL);

   $.ajax({
    type: 'GET',
    url: vendItemURL,
    
    success: function (data,status) 
    {
      var changeReturn='Quarters: '+data.quarters+', ';
      changeReturn+='Dimes: '+data.dimes+', ';
      changeReturn+='Nickels: '+data.nickels+', ';
      changeReturn+='Pennies: '+data.pennies;
      alert(changeReturn);
      $('#ChangeBox').text(changeReturn);
      $('#ItemCostBox').text('$0.00');
      $('#Message').text('Thank You!');
   },
 
  });
  GetItems()
  $('#TotalDeposit').text('').append('$0.00');
  $('#ItemNum').text('Item# None');
  }
 

function ChangeRtrn()
{
  var amount='$'+GetCellValue("DepRow").toFixed(2);
  $('#ChangeBox').text(amount);
  
  amount=0;
  var zeroTotal='$'+amount.toFixed(2);
  $('#TotalDeposit').text(zeroTotal);
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
  $('#TotalDeposit').text(newTotal);
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
        for (i=1;i<=9;i++)
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

function ShowSelection(cellNum)
{
  $('#Message').text('Message: None');
  $('#ItemNum').text('Item# None');

  var ckCell='Cell'+cellNum+'Quant'; 
  //alert(ckCell);

  var cellInfo=document.getElementById(ckCell).innerHTML;
  var ckQuant=cellInfo.substr(length-15,2);
  
  if (ckQuant>0)
  {
    $('#ItemNum').text('Item# '+ cellNum); 
      var newItem="Item #"+1;
      $('#ItemCostBox').text(newItem);

      var costID='Cell'+cellNum+'Cost';
      itemCost=document.getElementById(costID).innerHTML;
      $('#ItemCostBox').text('').append(itemCost);
  }
  else
  { $('#Message').text('Out of Stock!'); }
}


function GetCellValue(rowName)
{

var strTotal=document.getElementById("TotalDeposit").innerHTML;

//  var strTotal=document.getElementById("vendingTable").rows[1].cells.namedItem("TotalDeposit").innerHTML;
  var decTotal=strTotal.substr(1,strTotal.length-1).valueOf()*1;
  //var newTotal1=decTotal1+(addAmount.valueOf()*1);
  return decTotal;
}

function InitializeTable()
{
  GetItems();
  newAmount=0.0;
  UpdateTotal(newAmount);
  $('#ItemCostBox').text('').append('$0.00');
  $('#ItemNum').text('Item# None');
  $('#ChangeBox').text('').append('$0.00');
}