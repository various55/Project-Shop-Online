var size = 1;
var color = 1;
function GetCode() {
    var code = $('#coupon_code').val();
    $.ajax({
        url: '/Cart/GetCode',
        type: 'POST',
        dataType: "json",
        data: {
            code: code
        },
        beforeSend: function () {

        },
        success: function (res) {
            if (res['status']) {
                MessageSuccess('Áp dụng thành công mã code ' + res['discount'] +' % !');
                $('#price').text(res['total']);
                $('#discount').text(res['discount']+' %');
                $('#save').text(res['save']);
                $('#total').text(res['total']-res['save']);
            } else {
                MessageFailed('Code không tồi tại hoặc đã hết thời hạn sử dụng !');
            }
        },
        error: function (res) {
        },
        complete: function () {
        }
    })
}


function changeSize() {
    var size = $('input[name="size"]:checked').val();
    this.size = size??1;
    console.log(size);
}
function changeColor() {
    var color = $('input[name="color"]:checked').val();
    this.color = color??1;
    console.log(color);
}
function add(id) {
    var quantity = $('input[name="qty"]').val();
    var data = {
        id: id,
        action: 'add',
        size: this.size,
        color: this.color,
        quantity: quantity
    }
    $.ajax({
        url: '/Cart/Update',
        type: 'POST',
        contentType: 'application/json',
        dataType: "json",
        data: JSON.stringify(data),
        beforeSend: function () {

        },
        success: function (res) {
            if (res) {
                MessageSuccess('Thành công !');
                LoadCart();
            } else {
                MessageFailed('Sản phẩm bạn thêm k tồn tại hoặc đã hết hàng, liên hệ với nhân viên chúng tôi theo số điện thoại !');
            }
        },
        error: function (res) {
        },
        complete: function () {
        }
    })
}
function LoadCart() {
    $.ajax({
        url: '/Cart/LoadAll',
        type: 'POST',
        dataType: "json",
        beforeSend: function () {

        },
        success: function (res) {
            $('#quickCart').html('')
            $('#quickCart').html(res['quickCart'])
            $('#cart').html('')
            $('#cart').html(res['cart'])
        },
        error: function (res) {
        },
        complete: function () {
        }
    })
}
function update(id) {
    console.log(id);
    var quantity = $('input#' + id).val();
    var size = $('input[name="size"]#' + id).val();
    var color = $('input[name="color"]#' + id).val();
    console.log('quantity' + quantity);
    var data = {
        id: id,
        action: 'update',
        size: size??this.size,
        color: color??this.color,
        quantity: quantity
    }
    $.ajax({
        url: '/Cart/Update',
        type: 'POST',
        contentType: 'application/json',
        dataType: "json",
        data: JSON.stringify(data),
        beforeSend: function () {

        },
        success: function (res) {
            if (res) {
                MessageSuccess('Thành công !');
                LoadCart();
            } else {
                MessageFailed('Sản phẩm bạn thêm k tồn tại hoặc đã hết hàng, liên hệ với nhân viên chúng tôi theo số điện thoại !');
            }
        },
        error: function (res) {
        },
        complete: function () {
        }
    })
}
function remove(id) {
    var quantity = $('input[name="qty"]').val();
    var data = {
        id: id,
        action: 'delete',
        size: this.size,
        color: this.color,
        quantity: quantity
    }
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Cart/Update',
                type: 'POST',
                contentType: 'application/json',
                dataType: "json",
                data: JSON.stringify(data),
                beforeSend: function () {

                },
                success: function (res) {
                    if (res) {
                        MessageSuccess('Xóa thành công !');
                        LoadCart();
                    } else {
                        MessageFailed('Sản phẩm bạn xóa k có trong giỏ hàng !');
                    }
                },
                error: function (res) {
                },
                complete: function () {
                }
            })
        }
    })
}
function clear(e) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Cart/Clear',
                type: 'POST',
                contentType: 'application/json',
                dataType: "json",
                beforeSend: function () {

                },
                success: function (res) {
                    if (res) {
                        MessageSuccess('Thành công !');
                        LoadCart();
                    }
                },
                error: function (res) {
                },
                complete: function () {
                }
            })
        }
    })
}
function Checkout() {
    var data = GetData("Checkout");
    console.log(JSON.stringify(data));
    $.ajax({
        url: '/Cart/Checkout',
        type: 'POST',
        contentType: 'application/json',
        dataType: "json",
        data: JSON.stringify(data),
        beforeSend: function () {

        },
        success: function (res) {
            if (res) {
                MessageSuccess('Đặt hàng thành công, nhân viên sẽ sớm liên hệ lại quý khách để xác nhận, xin chân trọng cảm ơn ! !');
                $('#exampleModal').modal('toggle');
                LoadCart();
            }
        },
        error: function (res) {
        },
        complete: function () {
        }
    })
}
