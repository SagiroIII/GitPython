from django.db import models

# Create your models here.
# CREACION DE TABLAS
#CatPeliculas, CatJuegos, VentaJuego,VentaPeliculas,ProxEstrenos,CatePeliculas,CateJuegos

class CategoriaPeliculas(models.Model):
    TipoCategoria = models.CharField(max_length=20)


class ClasificacionJuegos(models.Model):
    TipoClasificacion = models.CharField(max_length=20)


class CategoriaJuegos(models.Model):
    TipoCategoria = models.CharField(max_length=20)


class Estrenos(models.Model):
    Titulo = models.CharField(max_length=50)
    Descripcion = models.CharField(max_length=300)
    Tipo = models.CharField(max_length=10)


class CatPeliculas(models.Model):
    Titulo = models.CharField(max_length=50)
    Categoria = models.ForeignKey(CategoriaPeliculas, on_delete=models.CASCADE)
    Descripcion = models.CharField(max_length=300)
    Duracion = models.IntegerField()
    Fecha = models.CharField(max_length=50)
    Precio = models.FloatField()


class VentasPeliculas(models.Model):
    Titulo = models.ForeignKey(CatPeliculas, on_delete=models.CASCADE)
    Precio = models.FloatField()
    NombreCliente = models.CharField(max_length=50)
    CorreoCliente = models.EmailField()
    FechaCompra = models.CharField(max_length=50)


class CatJuegos(models.Model):
    Titulo = models.CharField(max_length=50)
    Categoria = models.ForeignKey(CategoriaJuegos, on_delete=models.CASCADE)
    Descripcion = models.CharField(max_length=300)
    Clasificacion = models.ForeignKey(ClasificacionJuegos, on_delete=models.CASCADE)
    Fecha = models.CharField(max_length=50)
    Precio = models.FloatField()


class VentasJuegos(models.Model):
    Titulo = models.ForeignKey(CatJuegos, on_delete=models.CASCADE)
    Precio = models.FloatField()
    NombreCliente = models.CharField(max_length=50)
    CorreoCliente = models.EmailField()
    FechaCompra = models.CharField(max_length=50)