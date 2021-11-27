from django import forms


#Formulario para eliminar
class FormularioUsuarios(forms.Form):
    from VLIGSLog.models import Usuarios
    Usuario = forms.CharField()
    Nombre = forms.CharField(required=False)
    Apellido = forms.CharField(required=False)
    Correo = forms.EmailField(required=False)
    Contraseña = forms.CharField(required=False)


    #Formulario para insertar
class FormularioUsuarios2(forms.Form):
    from VLIGSLog.models import Usuarios
    Usuario = forms.CharField()
    Nombre = forms.CharField()
    Apellido = forms.CharField()
    Correo = forms.EmailField()
    Contraseña = forms.CharField()

