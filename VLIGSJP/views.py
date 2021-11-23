from django.shortcuts import render
from django.http import HttpResponse
from django.template import Template, Context
from django.template.loader import get_template

def CatalogoJuegos(request):
    return render(request, 'CatalogoJuegos.html')

def CatalogoPeliculas(request):
    return render(request, 'CatalogoPeliculas.html')

def VentaJuegos(request):
    return render(request, 'VentaJuegos.html')

def VentaPeliculas(request):
    return render(request, 'VentaPeliculas.html')

def CategoriaPeliculas(request):
    return render(request, 'CategoriaPeliculas.html')

def ClasifiacionJuegos(request):
    return render(request, 'ClasificacionJuegos.html')


