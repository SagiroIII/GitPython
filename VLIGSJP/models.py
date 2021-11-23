from django.db import models

# Create your models here.
# CREACION DE TABLAS
#CatPeliculas, CatJuegos, VentaJuego,VentaPeliculas,ProxEstrenos,CatePeliculas,CateJuegos

class CatPeliculas(models.Model):
    Titulo = models.CharField(max_length=50)
    Categoria = models.CharField(max_length=15)
    Descripcion = models.CharField(max_length=300)
    Duracion = models.IntegerField
    Fecha = models.CharField(max_length=10)
    Precio = models.FloatField

class VentasPeliculas (models.Model):
    Titulo = models.ForeignKey(CatPeliculas, on_delete=models.CASCADE)
    Precio = models.FloatField
    NombreCliente = models.CharField(max_length=15)
    CorreoCliente = models.EmailField
    FechaCompra = models.CharField(max_length=10)

class CatJuegos(models.Model):
    Titulo = models.CharField(max_length=50)
    Categoria = models.CharField(max_length=15)
    Descripcion = models.CharField(max_length=300)
    Clasificacion = models.CharField(max_length=10)
    Fecha = models.CharField(max_length=10)
    Precio = models.FloatField

class VentasJuegos (models.Model):
    Titulo = models.ForeignKey(CatJuegos, on_delete=models.CASCADE)
    Precio = models.FloatField
    NombreCliente = models.CharField(max_length=15)
    CorreoCliente = models.EmailField
    FechaCompra = models.CharField(max_length=10)

class ProximosEstrenos (models.Model):
    Titulo = models.CharField(max_length=50)
    Descripcion = models.CharField(max_length=300)
    Tipo = models.CharField(max_length=10)

class CategoriaPeliculas (models.Model):
    TipoCategoria = models.CharField(max_length=20)

class ClasificacionJuego (models.Model):
    TipoClasificacion = models.CharField(max_length=20)