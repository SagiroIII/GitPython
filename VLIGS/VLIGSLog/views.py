from django.shortcuts import render
import pymysql.connections
from django.http import HttpResponse
from django.template import Template, Context
from django.template.loader import get_template
from VLIGSLog.models import *
from VLIGSLog.formularios import *

#------------PRINCIPAL--------
def Principal(request):

    return render(request, 'Principal.html')


#--------------USUARIOS----------
def CrearUsuario(request):

    if request.method=="POST":
        formulario = FormularioUsuarios2(request.POST)

        if formulario.is_valid():
            usuario = formulario.cleaned_data.get("Usuario", "")
            nombre= formulario.cleaned_data.get("Nombre", "")
            apellido = formulario.cleaned_data.get("Apellido", "")
            correo = formulario.cleaned_data.get("Correo", "")
            contraseña = formulario.cleaned_data.get("Contraseña", "")
            insert =Usuarios(Usuario=usuario, Nombre=nombre,Apellido=apellido,Correo=correo,Contraseña=contraseña)
            insert.save()
        return render(request,"Usuario.html")
    else:
        formulario = FormularioUsuarios2()
    return render(request,"CreacionUsuario.html", {"form2":formulario})

def EliminarUsuario(request):
    if request.method == "POST":
        formulario = FormularioUsuarios(request.POST)
        if formulario.is_valid():
            usuario = formulario.cleaned_data.get("Usuario", "")
            borrar = Usuarios.objects.get(Usuario=usuario)
            borrar.delete()
        return render(request,"BorrarUsuario.html")

    else:
        formulario = FormularioUsuarios()
    return render(request, "EliminarUsuario.html", {"form": formulario})

#PARA MODIFICAR PAGINA DE ERRORES
def error404(request,exeption):
    return render(request, "404.html")
