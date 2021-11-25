from django.shortcuts import render
import pymysql.connections
from django.http import HttpResponse
from django.template import Template, Context
from django.template.loader import get_template
from VLIGSLog.models import Usuarios

#------------PRINCIPAL--------
def Principal(request):

    return render(request, 'Principal.html')

def InicioSesion(request):

    return render(request, 'InicioSesion.html')

#--------------USUARIOS----------
def CrearUsuario(request):
    return render(request, 'CreacionUsuario.html')

def ModificarUsuario(request):
    return render(request, 'ModificarUsuario.html')

def EliminarUsuario(request):
    return render(request, 'EliminarUsuario.html')

