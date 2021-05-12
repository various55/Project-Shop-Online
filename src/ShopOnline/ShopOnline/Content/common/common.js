﻿/*
 * idForm : Id của Form cần lấy dữ liệu client -> sv
 * url: Là url của Controller/Action cần để load dữ liệu lên
 * url_add: Là Controller/Action của cái add
 * url_delete: Là Controller/Action của cái delete
 * classAppend: là class của form cần đổ dữ liệu từ sv -> client
 * 
 */
/*
 * Hàm để Get dữ liệu từ form, tham số lưu ý trên đầu
 */
var dt = {
    pageNumber: 1,
    pageSize: 8,
    search: '',
    idCategory: 0
}
function GetData(idForm) {
    var unindexed_array = $('#' + idForm).serializeArray();
    var indexed_array = {};
    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });
    return indexed_array;
}
function getDataFillter(idCategory, pageNumber, url, classAppend) {
    dt.pageNumber = pageNumber;
    dt.idCategory = idCategory;
    $.ajax({
        url: url,
        type: "POST",
        dataType: "html",
        data: {
            pageNumber: dt.pageNumber,
            pageSize: dt.pageSize,
            search: dt.search,
            idCategory: dt.idCategory
        },
        beforeSend: function () {
        },
        success: function (res) {

            $('.' + classAppend + '').html('');
            $('.' + classAppend + '').append(res);
        },
        error: function () {

        },
        complete: function () {

        }
    })
}
function Search(idCategory, pageNumber, url, classAppend) {
    $('input[name="searchname"]').keyup(function () {
        dt.search = $(this).val();
        getDataFillter(idCategory, pageNumber, url, classAppend);
    })

}
function LoadData(url, classAppend) {
    $.ajax({
        url: url,
        type: "GET",
        dataType: "html",
        beforeSend: function () {
        },
        success: function (res) {
            $('.' + classAppend + '').html('');
            $('.' + classAppend + '').append(res);
        },
        error: function () {

        },
        complete: function () {
        }
    })
}
/*
 * Hàm để xóa, tham số lưu ý trên đầu
 */
function Delete(id, url_delete, url, classAppend) {

    Swal.fire({
        title: 'Bạn có chắc chắn không?',
        text: "Dữ liêu sau khi xóa sẽ bị mất, bạn vẫn muốn tiếp tục chứ!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Tiếp tục!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url_delete,
                type: 'POST',
                data: {
                    id: id
                },
                beforeSend: function () {

                },
                success: function (res) {
                    if (res == true) {
                        Swal.fire(
                            'Thành công!',
                            'Dữ liệu đã được xóa thành công.',
                            'success'
                        )
                        LoadData(url, classAppend);
                    } else {
                        Swal.fire(
                            'Thất bại!',
                            'Đã có lỗi xảy ra.',
                            'error'
                        )
                    }
                },
                error: function (res) {
                    Swal.fire(
                        'Thất bại!',
                        'Đã có lỗi xảy ra.',
                        'error'
                    )
                },
                complete: function () {
                }
            })
        }
    })
}

function AddOrUpdate(idForm, url_add, url, classAppend) {
    let data = GetData(idForm);
    $.ajax({
        url: url_add,
        type: 'POST',
        contentType: 'application/json',
        dataType: "json",
        data: JSON.stringify(data),
        beforeSend: function () {

        },
        success: function (res) {
            if (res) {
                MessageSuccess('thành công !');
            } else {
                MessageSuccess('Thêm thất bại !');
            }
        },
        error: function (res) {
        },
        complete: function () {
            $('#modalAdd').modal('toggle');
        }
    })
    $('#modalAdd').modal('toggle');
    LoadData(url, classAppend);
}
function AddLog(content, url_add) {
    $.ajax({
        url: url_add,
        type: 'POST',
        dataType: "json",
        data: { data: content },

        beforeSend: function () {
            console.log(url_add);
        },
        success: function (res) {

        },
        error: function (res) {
            alert("lỗi")
        },
        complete: function () {
            console.log('Đóng');
        }
    })
}
function getById(id, url, classAppend) {
    $.ajax({
        url: url,
        type: "POST",
        dataType: 'html',
        data: {
            id: id,
            pageNumber: dt.pageNumber,
            pageSize: dt.pageSize
        },
        beforeSend: function () {

        },
        success: function (res) {
            $('.' + classAppend + '').html('');
            $('.' + classAppend + '').append(res);
        },
        error: function () {

        },
        complete: function () {

        }
    })
}
function setDataForm(idForm, url, classAppend) {
    $.ajax({
        url: url,
        type: "Get",
        dataType: "html",
        data: {
            id: idForm
        },
        beforeSend: function () {
        },
        success: function (res) {
            $('.' + classAppend + '').html('');
            $('.' + classAppend + '').append(res);
        },
        error: function () {

        },
        complete: function () {

        }
    })
}
/* Validation form
 */
function Validation(idForm) {

}
function ValidEmail(email) {

}
/*
 * Thông báo thành công
 */
function MessageSuccess(mess) {
    Swal.fire({
        icon: 'success',
        title: 'Oops...',
        text: mess,
        footer: '<a href>Why do I have this issue?</a>'
    })
}
/**
 * Thông báo thất bại
 * @param {any} mess
 */
function MessageFailed(mess) {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: mess,
        footer: '<a href>Why do I have this issue?</a>'
    })
}