from django.shortcuts import render

# Create your views here.
from django.http import HttpResponse
from django.template import Template, Context
from django.template.loader import get_template
from VLIGSJP.models import *
from VLIGSJP.formularios import *


# ---------------CATALOGOS--------------
def CatalogoJuegos(request):
    catalogos = CatJuegos.objects.all()
    return render(request, 'CatalogoJuegos.html', {"catalogos": catalogos})


def CatalogoPeliculas(request):
    catalogop = CatPeliculas.objects.all()
    return render(request, 'CatalogoPeliculas.html', {"catalogos": catalogop})


# --------------VENTAS-----------
def VentaJuegos(request):
    catalogo = VentasJuegos.objects.all()
    return render(request, 'VentaJuegos.html', {"catalogos": catalogo})


def VentaPeliculas(request):
    catalogo = VentasPeliculas.objects.all()
    return render(request, 'VentaPeliculas.html', {"catalogos": catalogo})


# ---------------CATEGORIAS DE PELICULAS
def CategoriaPeliculas(request):
    return render(request, 'CategoriaPeliculas.html')


# ----------------CLASIFICACION DE JUEGOS-------------
def ClasifiacionJuegos(request):
    return render(request, 'ClasificacionJuegos.html')


# ------------------PELICULAS---------------

def CrearPelicula(request):
    if request.method == "POST":
        formulario = FormularioPeliculas2(request.POST)

        if formulario.is_valid():
            titulo = formulario.cleaned_data.get("Titulo", "")
            categoria = formulario.cleaned_data.get("Categoria", "")
            descripcion = formulario.cleaned_data.get("Descripcion", "")
            duracion = formulario.cleaned_data.get("Duracion", "")
            fecha = formulario.cleaned_data.get("Fecha", "")
            precio = formulario.cleaned_data.get("Precio", "")

            insert = CatPeliculas(Titulo=titulo, Categoria_id=categoria, Descripcion=descripcion, Duracion=duracion,
                                  Fecha=fecha, Precio=precio)
            insert.save()
        return render(request, "Peliculas.html")
    else:
        formulario = FormularioPeliculas2()
    return render(request, "CrearPelicula.html", {"form2": formulario})


def EliminarPelicula(request):
    if request.method == "POST":
        formulario = FormularioPeliculas(request.POST)
        if formulario.is_valid():
            titulo = formulario.cleaned_data.get("Titulo", "")
            borrar = CatPeliculas.objects.get(Titulo=titulo)
            borrar.delete()
        return render(request, "BorrarPelicula.html")

    else:
        formulario = FormularioPeliculas()
    return render(request, "EliminarPelicula.html", {"form": formulario})


# ----------------JUEGOS------------------
def CrearJuego(request):
    if request.method == "POST":
        formulario = FormularioJuegos2(request.POST)

        if formulario.is_valid():
            titulo = formulario.cleaned_data.get("Titulo", "")
            categoria = formulario.cleaned_data.get("Categoria", "")
            descripcion = formulario.cleaned_data.get("Descripcion", "")
            clasificacion = formulario.cleaned_data.get("Clasificacion", "")
            fecha = formulario.cleaned_data.get("Fecha", "")
            precio = formulario.cleaned_data.get("Precio", "")

            insert = CatJuegos(Titulo=titulo, Categoria_id=categoria, Descripcion=descripcion,
                               Clasificacion_id=clasificacion, Fecha=fecha, Precio=precio)
            insert.save()
        return render(request, "Juegos.html")
    else:
        formulario = FormularioJuegos2()
    return render(request, "CrearJuego.html", {"form2": formulario})


def EliminarJuego(request):
    if request.method == "POST":
        formulario = FormularioJuegos(request.POST)
        if formulario.is_valid():
            titulo = formulario.cleaned_data.get("Titulo", "")
            borrar = CatJuegos.objects.get(Titulo=titulo)
            borrar.delete()
        return render(request, "BorrarJuego.html")

    else:
        formulario = FormularioJuegos()
    return render(request, "EliminarJuego.html", {"form": formulario})


# REGISTRO PROXIMOS ESTRENOS
def ProximosEstrenos(request):
    if request.method == "POST":
        formulario = FormularioEstrenos(request.POST)

        if formulario.is_valid():
            titulo = formulario.cleaned_data.get("Titulo", "")
            descripcion = formulario.cleaned_data.get("Descripcion", "")
            tipo = formulario.cleaned_data.get("Tipo", "")
            insert = Estrenos(Titulo=titulo, Descripcion=descripcion, Tipo=tipo)
            insert.save()
        return render(request, "Estreno.html")
    else:
        formulario = FormularioEstrenos()
    return render(request, "RegistroProximosEstrenos.html", {"form10": formulario})


# -----CATALOGONO ESTREENOS
def CatalogoEstrenos(request):
    estrenos = Estrenos.objects.all()
    return render(request, 'CatalogoEstrenos.html', {"estrenos": estrenos})


# -------VENTAS
def RegistrarVPeliculas(request):
    if request.method == "POST":
        formulario = FormularioPeliculas3(request.POST)

        if formulario.is_valid():
            precio = formulario.cleaned_data.get("Precio", "")
            cliente = formulario.cleaned_data.get("Cliente", "")
            correo = formulario.cleaned_data.get("Correo", "")
            fecha = formulario.cleaned_data.get("Fecha", "")
            titulo = formulario.cleaned_data.get("IdPelicula", "")

            insert = VentasPeliculas(Precio=precio, NombreCliente=cliente, CorreoCliente=correo, FechaCompra=fecha,
                                     Titulo_id=titulo)
            insert.save()
        return render(request, "VPeliculas.html")
    else:
        formulario = FormularioPeliculas3()
    return render(request, "RegistrarVPeliculas.html", {"form3": formulario})


def RegistrarVJuegos(request):
    if request.method == "POST":
        formulario = FormularioJuegos3(request.POST)

        if formulario.is_valid():
            precio = formulario.cleaned_data.get("Precio", "")
            cliente = formulario.cleaned_data.get("Cliente", "")
            correo = formulario.cleaned_data.get("Correo", "")
            fecha = formulario.cleaned_data.get("Fecha", "")
            titulo = formulario.cleaned_data.get("IdJuego", "")

            insert = VentasJuegos(Precio=precio, NombreCliente=cliente, CorreoCliente=correo, FechaCompra=fecha,
                                  Titulo_id=titulo)
            insert.save()
        return render(request, "VJuegos.html")
    else:
        formulario = FormularioJuegos3()
    return render(request, "RegistrarVJuegos.html", {"form3": formulario})


# PARA MODIFICAR PAGINA DE ERRORES
def error404(request, exeption):
    return render(request, "404.html")


def error500(request):
    return render(request, "Error500.html")