from django.shortcuts import render
from django.http import HttpResponse
from django.template import Template, Context
from django.template.loader import get_template

def CrearUsuario(request):
    return render(request, 'CreacionUsuario.html')

def ModificarUsuario(request):
    return render(request, 'ModificarUsuario.html')

def EliminarUsuario(request):
    return render(request, 'EliminarUsuario.html')

