
$(document).ready(function() {

    InitializeTable();

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

} 
function CkPurchase()
{
  var StrPurchasePrice=document.getElementById("ItemCostBox").innerHTML;
  var length=StrPurchasePrice.length-1;
  var purchasePrice=StrPurchasePrice.substr(1,length)*1;

  var StrCrntDeposit = document.getElementById("TotalDeposit").innerHTML;
  length=StrCrntDeposit.length-1;
  var crntDeposit=StrCrntDeposit.substr(1,length)*1;

  myVar=(purchasePrice+", "+crntDeposit);

  if (purchasePrice=="0") 
  { $('#Message').text('Please choose an item.'); }

  else if (purchasePrice>crntDeposit)
  {
    var amtNeeded=purchasePrice-crntDeposit;
    $('#Message').text('Please add $' + amtNeeded.toFixed(2)); }
  else
  {
    MkPurchase();
  }

}

function MkPurchase()
{  
    var vendItemURL= 'http://localhost:8080/money/';
    var itemNum=document.getElementById("ItemNum").innerHTML;
    itemNum=itemNum.substr(itemNum.length-1,1);
    var depAmt=document.getElementById("TotalDeposit").innerHTML;
    depAmt=depAmt.substr(1,depAmt.length-1);
    vendItemURL+=depAmt+'/'+ 'item/'+itemNum;
   //$('#Message').text(vendItemURL);

   $.ajax({
    type: 'GET',
    url: vendItemURL,
    
    success: function (data,status) 
    {
      var changeReturn='Quarters: '+data.quarters+', ';
      changeReturn+='Dimes: '+data.dimes+', ';
      changeReturn+='Nickels: '+data.nickels+', ';
      changeReturn+='Pennies: '+data.pennies;
      //alert(changeReturn);
      $('#ChangeBox').text(changeReturn);
      $('#ItemCostBox').text('$0.00');
      $('#Message').text('Thank You!');
   },
 
   error: function () {
    alert("Connection to server failed, when making a purchase.");
   }

  });
  GetItems()
  $('#TotalDeposit').text('$0.00');
  $('#ItemNum').text('Item# None');
  }
 

function ChangeRtrn()
{
  $('#ItemNum').text('Item# None');
  $('#ItemCostBox').text('$0.00');
  var amount=Math.round(GetCellValue("DepRow")*100);

//amount*=100;
var numQuarts=parseInt(amount/25);
amount%=25;
var numDimes=parseInt(amount/10);
amount%=10;
var numNicks=parseInt(amount/5);

var numPennies=amount%5;
//amount-=numNicks* 5;
//amount/=100;

var changeMsg='Quarters: '+numQuarts+', Dimes: '+numDimes+', Nickels: '+numNicks+', Pennies: '+numPennies;

  $('#ChangeBox').text(changeMsg);
  
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
          
          var cellID=data[i-1].id;
          var nameInfo=data[i-1].name+"<br />";
          var costInfo=data[i-1].price.valueOf().toFixed(2);
          var quantInfo="Qunatity Left: "+data[i-1].quantity+"<br />";
                  
          cellID= '<div align=\"left\">'+cellID+'<br></div>';
          
          nameInfo=cellID+nameInfo;
          costInfo='$'+costInfo;
          quantInfo=quantInfo;

          $(nameCell).text('').append(nameInfo)+'<p>';
          $(costCell).text('').append(costInfo)+'<p>';
          $(quantCell).text('').append(quantInfo)+'<p>';
        }   
    },
    error: function () {
      alert("Connection to server failed, when requesting all items.");
  }
  
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
  
  var cellInfo=document.getElementById(ckCell).innerHTML;
  var ckQuant=cellInfo.substr(length-6,2);
  if (ckQuant.substr(0,1)==" ") 
  {
    ckQuant=ckQuant.substr(1,1);
  }

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