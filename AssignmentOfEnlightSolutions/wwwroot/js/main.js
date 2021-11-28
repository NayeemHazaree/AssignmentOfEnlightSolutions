showitems();
let additeminput = document.getElementById("item");
let additemname = document.getElementById("itemName")
let addpriceinput = document.getElementById("price");
let addquantityinput = document.getElementById("quantity");
let addtotalpriceinput = document.getElementById("totalPrice");
let additembtn = document.getElementById("additems");

const array = [];
let addtp = document.getElementById("tp");
//set the items first
additembtn.addEventListener("click", function () {
    additeminputval = $("#item option:selected").text();

    addpriceinputval = price.value;
    
    addquantitynputval = quantity.value;
    
    addtotalpriceinputval = totalPrice.value;
    
    if (addpriceinputval.trim() != 0 && addquantitynputval.trim() != 0 && addtotalpriceinputval.trim() != 0 ) {
        let webtask = localStorage.getItem("localtask");
        if (webtask == null) {
            taskObj = [];
        }
        else {
            taskObj = JSON.parse(webtask);
        }
        taskObj.push({ 'Item_ID': additeminputval, 'Item_price': addpriceinputval, 'Item_quantity': addquantitynputval, 'Total_Price': addtotalpriceinputval, 'completeStatus': false});
        localStorage.setItem("localtask", JSON.stringify(taskObj));
        additeminput.value = '';
        addpriceinput.value = '';
        addquantityinput.value = '';
        addtotalpriceinput.value = '';

        array.push(addtotalpriceinputval);
        
        var total = 0;
        for (var i = 0; i < array.length; i++) {
            total += parseInt(array[i]);
        }
        
        
    }
    showitems();
})
//Showing the items on page
function showitems() {
    let webtask = localStorage.getItem("localtask");
    if (webtask == null) {
        taskObj = [];
    }
    else {
        taskObj = JSON.parse(webtask);
    }
    let html = '';
    let addeditemlist = document.getElementById("addeditemlist");
    taskObj.forEach((items,index) => {

        html += `<tr>
                    <tbody>
                    <tr>
                    <td>${items.Item_ID}</td>
                    <td>${items.Item_price}</td>
                    <td>${items.Item_quantity}</td>
                    <td>${items.Total_Price}</td>
                    <td><button type="button" onclick="deleteitem(${index})" class="text-danger"><i class="fa fa-trash"></i>Delete</button></td>

                    </tr>

                    </tbody>
                </tr>`;
    });
    addeditemlist.innerHTML = html;
}

//delete the items
function deleteitem(index) {
    let webtask = localStorage.getItem("localtask");
    let taskObj = JSON.parse(webtask);
    taskObj.splice(index, 1);
    localStorage.setItem("localtask", JSON.stringify(taskObj));
    showitems();
}
