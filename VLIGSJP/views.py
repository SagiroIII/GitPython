from django.shortcuts import render
from django.http import HttpResponse
from django.template import Template, Context
from django.template.loader import get_template

#---------------CATALOGOS--------------
def CatalogoJuegos(request):
    return render(request, 'CatalogoJuegos.html')

def CatalogoPeliculas(request):
    return render(request, 'CatalogoPeliculas.html')

#--------------VENTAS-----------
def VentaJuegos(request):
    return render(request, 'VentaJuegos.html')

def VentaPeliculas(request):
    return render(request, 'VentaPeliculas.html')

#---------------CATEGORIAS DE PELICULAS
def CategoriaPeliculas(request):
    return render(request, 'CategoriaPeliculas.html')

#----------------CLASIFICACION DE JUEGOS-------------
def ClasifiacionJuegos(request):
    return render(request, 'ClasificacionJuegos.html')


#------------------PELICULAS---------------

def CrearPelicula(request):
    return render(request, 'CrearPelicula.html')
def ModificarPelicula(request):
    return render(request, 'ModificarPelicula.html')
def EliminarPelicula(request):
    return render(request, 'EliminarPelicula.html')

#----------------JUEGOS------------------
def CrearJuego(request):
    return render(request, 'CrearJuego.html')
def ModificarJuego(request):
    return render(request, 'ModificarJuego.html')
def EliminarJuego(request):
    return render(request, 'EliminarJuego.html')

