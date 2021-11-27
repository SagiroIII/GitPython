function mostrar(){
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
    Swal.fire(
      'Deleted!',
      'Your file has been deleted.',
      'success'
    )
  }
})
}

function confirmacion(){
  Swal.fire({
  position: 'top-end',
  icon: 'success',
  title: 'La película ha sido guardada correctamente',
  showConfirmButton: false,
  timer: 1500
})
}

function confijuego(){
  Swal.fire({
  position: 'top-end',
  icon: 'success',
  title: 'El juego ha sido registrado correctamente',
  showConfirmButton: false,
  timer: 1500
})
}

function confiuser(){
  Swal.fire({
  position: 'top-end',
  icon: 'success',
  title: 'El usuario ha sido registrado correctamente',
  showConfirmButton: false,
  timer: 1500
})
}