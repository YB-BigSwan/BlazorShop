window.showToastr = (type, message) => {
    toastr.options.positionClass = "toast-bottom-left";


    if(type === "success"){
        toastr.success(message, 'Operation successful', {timeOut: 5000})
    }

    if(type === "error") {
        toastr.error(message, 'Operation failed', {timeOut: 5000})
    }
}

window.showSweetAlert = (type, title, message) => {

    if(type === "success"){
        Swal.fire({
            title: title,
            text: message,
            icon: type
        })
    }

    if(type === "error"){
        Swal.fire({
            title: title,
            text: message,
            icon: type
        })
    }
}

function ShowDeleteConfirmationModal(){
    event.preventDefault();
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal(){
    event.preventDefault();
    $('#deleteConfirmationModal').modal('hide');
}