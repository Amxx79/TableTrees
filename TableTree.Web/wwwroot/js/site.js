 solve()

//  function solve() {
//      var cartQuantityInputElement = document.getElementsByClassName('cart-quantity-input')

//      for (let i = 0; i < cartQuantityInputElement.length; i++) {
//          var input = cartQuantityInputElement[i];
//          input.addEventListener('change', updateCartTotal)
//          console.log(input);
//      }
//  }

//  function updateCartTotal() {
//     //  var totalPrice = 0;

//     //  var cartRows = document.getElementsByClassName('cart-row');
//     //  for (var i = 0; i < cartRows.length; i++) {
//     //      var cartRow = cartRows[i];

//     //      var priceElement = cartRow.getElementsByClassName('cart-price')[0];
//     //      var cartQuantityInputElement = document.getElementsByClassName('cart-quantity-input')
//     //      var quantity = cartQuantityInputElement[i].value;
//     //      var price = parseFloat(priceElement.innerText.replace('ЛВ.', '').replace(/\s/g, '').replace(',', '.'));
    
//     //     totalPrice += price * quantity;
//     //     var productId = document.getElementById('productId');
// }

function solve() {
    var cartQuantityInputElements = document.getElementsByClassName('cart-quantity-input');
    console.log(cartQuantityInputElements.value);
    
    for (let i = 0; i < cartQuantityInputElements.length; i++) {
        var input = cartQuantityInputElements[i];
        var productId = document.getElementById('productId');
        
        input.addEventListener('change', function () {
            updateCartTotal(productId, i);
        });
    }
}

function updateCartTotal(productId, index) {
    var cartRow = document.getElementsByClassName('cart-row');
    
    var priceElement = document.getElementsByClassName('cart-price')[index];
    var quantityElement = document.getElementsByClassName('cart-quantity-input')[index];
    
    var quantity = quantityElement.value;
    var price = parseFloat(priceElement.innerText.replace('ЛВ.', '').replace(/\s/g, '').replace(',', '.'));

    // var form = document.getElementById('form');
    var form = cartRow[index].querySelector('#form');
    console.log(form);
    form.submit();
}
