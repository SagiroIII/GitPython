from django.db import models

# Create your models here.

#USUARIOS PARA LOGIN
class Usuarios (models.Model):
    Usuario = models.CharField(max_length=15)
    Nombre = models.CharField(max_length=50)
    Apellido = models.CharField(max_length=50)
    Correo = models.EmailField()
    Contraseña = models.CharField(max_length=20)


