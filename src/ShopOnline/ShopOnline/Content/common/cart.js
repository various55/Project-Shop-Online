function LoadCart() {
    $.ajax({
        url: '/Cart/LoadAll',
        type: 'get',
        dataType: 'json',
        success: (res) => {
            console.log(res['quickCartPartial']);
            $('#quickCart').html('')
            $('#quickCart').html(res['quickCartPartial'])
        },
        error(res) {
            console.log(res)
        },
        complete:()=>{

        }
    })
}