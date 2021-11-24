"""VLIGS URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/3.2/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from django.urls import path
from VLIGSJP.views import *
from VLIGSLog.views import *

urlpatterns = [

    #-----PAGINA PRINCIPAL
    path('Principal/',Principal),
    path('admin/', admin.site.urls),
    path('CatalogoJuegos/', CatalogoJuegos),
    path('CatalogoPeliculas/', CatalogoPeliculas),
    path('VentaJuegos/', VentaJuegos),
    path('VentaPeliculas/', VentaPeliculas),
    path('CategoriaPeliculas/', CategoriaPeliculas),
    path('ClasificacionJuegos/', ClasifiacionJuegos),
    #-----USUARIOS
    path('CrearUsuario/', CrearUsuario),
    path('ModificarUsuario/',ModificarUsuario),
    path('EliminarUsuario/', EliminarUsuario),
    #----JUEGOS----
    path('CrearJuego/', CrearJuego),
    path('ModificarJuego/',ModificarJuego),
    path('EliminarJuego/', EliminarJuego),
    #-----PELICULAS---
    path('CrearPelicula/', CrearPelicula),
    path('ModificarPelicula/',ModificarPelicula),
    path('EliminarPelicula/', EliminarPelicula),
    #-----Dashboard-----
    path("dashpelicula", pelicula)

]
