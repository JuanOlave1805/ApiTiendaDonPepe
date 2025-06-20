PGDMP                      }            TiendaDonPepe    16.9    16.9 4    R           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            S           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            T           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            U           1262    24576    TiendaDonPepe    DATABASE     �   CREATE DATABASE "TiendaDonPepe" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Colombia.1252';
    DROP DATABASE "TiendaDonPepe";
                postgres    false            �            1259    24607 
   Categorias    TABLE     \   CREATE TABLE public."Categorias" (
    "Id" integer NOT NULL,
    "Nombre" text NOT NULL
);
     DROP TABLE public."Categorias";
       public         heap    postgres    false            �            1259    24695    Categorias_Id_seq    SEQUENCE     �   ALTER TABLE public."Categorias" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Categorias_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    218            �            1259    24651    Ordenes    TABLE     {  CREATE TABLE public."Ordenes" (
    "Id" integer NOT NULL,
    "Usuario_id" integer,
    "Producto_id" integer,
    "Cantidad" integer NOT NULL,
    "Fecha" timestamp without time zone DEFAULT now(),
    "Tipo" character varying(20),
    CONSTRAINT "Ordenes_Tipo_check" CHECK ((("Tipo")::text = ANY ((ARRAY['Venta'::character varying, 'Compra'::character varying])::text[])))
);
    DROP TABLE public."Ordenes";
       public         heap    postgres    false            �            1259    24693    Ordenes_Id_seq    SEQUENCE     �   ALTER TABLE public."Ordenes" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Ordenes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    224            �            1259    24631 	   Productos    TABLE     �   CREATE TABLE public."Productos" (
    "Id" integer NOT NULL,
    "Nombre" text NOT NULL,
    "Precio" numeric(10,2) NOT NULL,
    "Stock" integer DEFAULT 0 NOT NULL,
    "Categoria_id" integer,
    "Proveedor_id" integer
);
    DROP TABLE public."Productos";
       public         heap    postgres    false            �            1259    24700    Productos_Id_seq    SEQUENCE     �   ALTER TABLE public."Productos" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Productos_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    222            �            1259    24618    Proveedores    TABLE     v   CREATE TABLE public."Proveedores" (
    "Id" integer NOT NULL,
    "Nombre" text NOT NULL,
    "Nit" text NOT NULL
);
 !   DROP TABLE public."Proveedores";
       public         heap    postgres    false            �            1259    24691    Proveedores_Id_seq    SEQUENCE     �   ALTER TABLE public."Proveedores" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Proveedores_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    220            �            1259    24594    Usuarios    TABLE       CREATE TABLE public."Usuarios" (
    "Id" integer NOT NULL,
    "Nombres" character varying(100) NOT NULL,
    "Apellidos" character varying(100) NOT NULL,
    "Correo" character varying(150) NOT NULL,
    "Usuario" character varying(50) NOT NULL,
    "Clave" text NOT NULL
);
    DROP TABLE public."Usuarios";
       public         heap    postgres    false            �            1259    24606    categorias_id_seq    SEQUENCE     �   CREATE SEQUENCE public.categorias_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.categorias_id_seq;
       public          postgres    false    218            V           0    0    categorias_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.categorias_id_seq OWNED BY public."Categorias"."Id";
          public          postgres    false    217            �            1259    24650    ordenes_id_seq    SEQUENCE     �   CREATE SEQUENCE public.ordenes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.ordenes_id_seq;
       public          postgres    false    224            W           0    0    ordenes_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.ordenes_id_seq OWNED BY public."Ordenes"."Id";
          public          postgres    false    223            �            1259    24630    productos_id_seq    SEQUENCE     �   CREATE SEQUENCE public.productos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.productos_id_seq;
       public          postgres    false    222            X           0    0    productos_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.productos_id_seq OWNED BY public."Productos"."Id";
          public          postgres    false    221            �            1259    24617    proveedores_id_seq    SEQUENCE     �   CREATE SEQUENCE public.proveedores_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.proveedores_id_seq;
       public          postgres    false    220            Y           0    0    proveedores_id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.proveedores_id_seq OWNED BY public."Proveedores"."Id";
          public          postgres    false    219            �            1259    24593    usuarios_id_seq    SEQUENCE     �   CREATE SEQUENCE public.usuarios_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.usuarios_id_seq;
       public          postgres    false    216            Z           0    0    usuarios_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.usuarios_id_seq OWNED BY public."Usuarios"."Id";
          public          postgres    false    215            �           2604    24597    Usuarios Id    DEFAULT     n   ALTER TABLE ONLY public."Usuarios" ALTER COLUMN "Id" SET DEFAULT nextval('public.usuarios_id_seq'::regclass);
 >   ALTER TABLE public."Usuarios" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    216    215    216            E          0    24607 
   Categorias 
   TABLE DATA           6   COPY public."Categorias" ("Id", "Nombre") FROM stdin;
    public          postgres    false    218   n;       K          0    24651    Ordenes 
   TABLE DATA           c   COPY public."Ordenes" ("Id", "Usuario_id", "Producto_id", "Cantidad", "Fecha", "Tipo") FROM stdin;
    public          postgres    false    224   �;       I          0    24631 	   Productos 
   TABLE DATA           h   COPY public."Productos" ("Id", "Nombre", "Precio", "Stock", "Categoria_id", "Proveedor_id") FROM stdin;
    public          postgres    false    222   �;       G          0    24618    Proveedores 
   TABLE DATA           >   COPY public."Proveedores" ("Id", "Nombre", "Nit") FROM stdin;
    public          postgres    false    220   8<       C          0    24594    Usuarios 
   TABLE DATA           `   COPY public."Usuarios" ("Id", "Nombres", "Apellidos", "Correo", "Usuario", "Clave") FROM stdin;
    public          postgres    false    216   |<       [           0    0    Categorias_Id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Categorias_Id_seq"', 4, true);
          public          postgres    false    227            \           0    0    Ordenes_Id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Ordenes_Id_seq"', 27, true);
          public          postgres    false    226            ]           0    0    Productos_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Productos_Id_seq"', 5, true);
          public          postgres    false    228            ^           0    0    Proveedores_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Proveedores_Id_seq"', 7, true);
          public          postgres    false    225            _           0    0    categorias_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.categorias_id_seq', 1, false);
          public          postgres    false    217            `           0    0    ordenes_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.ordenes_id_seq', 1, false);
          public          postgres    false    223            a           0    0    productos_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.productos_id_seq', 1, false);
          public          postgres    false    221            b           0    0    proveedores_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.proveedores_id_seq', 1, true);
          public          postgres    false    219            c           0    0    usuarios_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.usuarios_id_seq', 1, false);
          public          postgres    false    215            �           2606    24616     Categorias categorias_nombre_key 
   CONSTRAINT     a   ALTER TABLE ONLY public."Categorias"
    ADD CONSTRAINT categorias_nombre_key UNIQUE ("Nombre");
 L   ALTER TABLE ONLY public."Categorias" DROP CONSTRAINT categorias_nombre_key;
       public            postgres    false    218            �           2606    24614    Categorias categorias_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Categorias"
    ADD CONSTRAINT categorias_pkey PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."Categorias" DROP CONSTRAINT categorias_pkey;
       public            postgres    false    218            �           2606    24660    Ordenes ordenes_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Ordenes"
    ADD CONSTRAINT ordenes_pkey PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Ordenes" DROP CONSTRAINT ordenes_pkey;
       public            postgres    false    224            �           2606    24639    Productos productos_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Productos"
    ADD CONSTRAINT productos_pkey PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."Productos" DROP CONSTRAINT productos_pkey;
       public            postgres    false    222            �           2606    24629    Proveedores proveedores_nit_key 
   CONSTRAINT     ]   ALTER TABLE ONLY public."Proveedores"
    ADD CONSTRAINT proveedores_nit_key UNIQUE ("Nit");
 K   ALTER TABLE ONLY public."Proveedores" DROP CONSTRAINT proveedores_nit_key;
       public            postgres    false    220            �           2606    24627 "   Proveedores proveedores_nombre_key 
   CONSTRAINT     c   ALTER TABLE ONLY public."Proveedores"
    ADD CONSTRAINT proveedores_nombre_key UNIQUE ("Nombre");
 N   ALTER TABLE ONLY public."Proveedores" DROP CONSTRAINT proveedores_nombre_key;
       public            postgres    false    220            �           2606    24625    Proveedores proveedores_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Proveedores"
    ADD CONSTRAINT proveedores_pkey PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."Proveedores" DROP CONSTRAINT proveedores_pkey;
       public            postgres    false    220            �           2606    24603    Usuarios usuarios_correo_key 
   CONSTRAINT     ]   ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT usuarios_correo_key UNIQUE ("Correo");
 H   ALTER TABLE ONLY public."Usuarios" DROP CONSTRAINT usuarios_correo_key;
       public            postgres    false    216            �           2606    24601    Usuarios usuarios_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT usuarios_pkey PRIMARY KEY ("Id");
 B   ALTER TABLE ONLY public."Usuarios" DROP CONSTRAINT usuarios_pkey;
       public            postgres    false    216            �           2606    24605    Usuarios usuarios_usuario_key 
   CONSTRAINT     _   ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT usuarios_usuario_key UNIQUE ("Usuario");
 I   ALTER TABLE ONLY public."Usuarios" DROP CONSTRAINT usuarios_usuario_key;
       public            postgres    false    216            �           2606    24666     Ordenes ordenes_producto_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Ordenes"
    ADD CONSTRAINT ordenes_producto_id_fkey FOREIGN KEY ("Producto_id") REFERENCES public."Productos"("Id");
 L   ALTER TABLE ONLY public."Ordenes" DROP CONSTRAINT ordenes_producto_id_fkey;
       public          postgres    false    222    4780    224            �           2606    24661    Ordenes ordenes_usuario_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Ordenes"
    ADD CONSTRAINT ordenes_usuario_id_fkey FOREIGN KEY ("Usuario_id") REFERENCES public."Usuarios"("Id");
 K   ALTER TABLE ONLY public."Ordenes" DROP CONSTRAINT ordenes_usuario_id_fkey;
       public          postgres    false    216    224    4766            �           2606    24640 %   Productos productos_categoria_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Productos"
    ADD CONSTRAINT productos_categoria_id_fkey FOREIGN KEY ("Categoria_id") REFERENCES public."Categorias"("Id");
 Q   ALTER TABLE ONLY public."Productos" DROP CONSTRAINT productos_categoria_id_fkey;
       public          postgres    false    218    4772    222            �           2606    24645 %   Productos productos_proveedor_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Productos"
    ADD CONSTRAINT productos_proveedor_id_fkey FOREIGN KEY ("Proveedor_id") REFERENCES public."Proveedores"("Id");
 Q   ALTER TABLE ONLY public."Productos" DROP CONSTRAINT productos_proveedor_id_fkey;
       public          postgres    false    4778    220    222            E   '   x�3�tN�K,.ITpK����L,�2�t,N������ ��      K   6   x�32�4�4�44�4202�50�54T00�22�26�340�t��-(J����� �{�      I   =   x�3�tO,N�/NT��Fz���Ɯ�\��N��
`\��i�3bcN3�=... �~�      G   4   x�3�t����M��K�421210�2��/.�O���44262153�����       C   =   x�3��*M��8��(��39��(5�B�%��r:��f�e�%��q��r��qqq S�     