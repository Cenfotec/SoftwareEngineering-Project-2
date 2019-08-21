function SelectProvinces() {
    const selectProvincias = document.querySelector('#inputProvincia');
    const selectCantones = document.querySelector('#inputCanton');
    const selectDistrito = document.querySelector('#inputDistrito');

    const optionProvincias = document.querySelector('#optionProvincias');
    const optionCantones = document.querySelector('#optionCantones');

    const provincias = ['San José', 'Alajuela', 'Cartago', 'Heredia', 'Guanacaste', 'Puntarenas', 'Limón'];
    const cantones = [
        'San José',
        'Escazú',
        'Desamparados',
        'Puriscal',
        'Tarrazú',
        'Aserrí',
        'Mora',
        'Goicoechea',
        'Santa Ana',
        'Alajuelita',
        'Vasquez de Coronado',
        'Acosta',
        'Tibás',
        'Moravia',
        'Montes de Oca',
        'Turrubares',
        'Dota',
        'Curridabat',
        'Pérez Zeledón',
        'León Cortés',
        'Alajuela',
        'San Ramón',
        'Grecia',
        'San Mateo',
        'Atenas',
        'Naranjo',
        'Palmares',
        'Poás',
        'Orotina',
        'San Carlos',
        'Valverde Vega',
        'Upala',
        'Los Chiles',
        'Zarcero',
        'Guatuso',
        'Rio Cuarto',
        'Cartago',
        'Paraíso',
        'La Unión',
        'Jiménez',
        'Turrialba',
        'Alvarado',
        'Oreamuno',
        'El Guarco',
        'Heredia',
        'Barva',
        'Santo Domingo',
        'Santa Bárbara',
        'San Rafael',
        'San Isidro',
        'Belén',
        'Flores',
        'San Pablo',
        'Sarapiquí ',
        'Liberia',
        'Nicoya',
        'Santa Cruz',
        'Bagaces',
        'Carrillo',
        'Cañas',
        'Abangares',
        'Tilarán',
        'Nandayure',
        'La Cruz',
        'Hojancha',
        'Puntarenas',
        'Esparza',
        'Buenos Aires',
        'Montes de Oro',
        'Osa',
        'Quepos',
        'Golfito',
        'Coto Brus',
        'Parrita',
        'Corredores',
        'Garabito',
        'Limón',
        'Pococí',
        'Siquirres ',
        'Talamanca',
        'Matina',
        'Guácimo'
    ];

    const distritos = [

        'Carmen',
        'Merced',
        'Hospital',
        'Catedral',
        'Zapote',
        'San Francisco de Dos Ríos',
        'Uruca',
        'Mata Redonda',
        'Pavas',
        'Hatillo',
        'San Sebastián',
        'Escazú',
        'San Antonio',
        'San Rafael',
        'Desamparados',
        'San Miguel',
        'San Juan de Dios',
        'San Rafael Arriba',
        'San Antonio',
        'Frailes',
        'Patarrá',
        'San Cristóbal',
        'Rosario',
        'Damas',
        'San Rafael Abajo',
        'Gravilias',
        'Los Guido',
        'Santiago',
        'Mercedes Sur',
        'Barbacoas',
        'Grifo Alto',
        'San Rafael',
        'Candelaria',
        'Desamparaditos',
        'San Antonio',
        'Chires',
        'San Marcos',
        'San Lorenzo',
        'San Carlos',
        'Aserrí',
        'Tarbaca o Praga',
        'Vuelta de Jorco',
        'San Gabriel',
        'La Legua',
        'Monterrey',
        'Salitrillos',
        'Colón',
        'Guayabo',
        'Tabarcia',
        'Piedras Negras',
        'Picagres',
        'Guadalupe',
        'San Francisco',
        'Calle Blancos',
        'Mata de Plátano',
        'Ipís',
        'Rancho Redondo',
        'Purral',
        'Santa Ana',
        'Salitral',
        'Pozos o Concepción',
        'Uruca o San Joaquín',
        'Piedades',
        'Brasil',
        'Alajuelita',
        'San Josecito',
        'San Antonio',
        'Concepción',
        'San Felipe',
        'San Isidro',
        'San Rafael',
        'Dulce Nombre de Jesús',
        'Patalillo',
        'Cascajal',
        'San Ignacio',
        'Guaitil',
        'Palmichal',
        'Cangrejal',
        'Sabanillas',
        'San Juan',
        'Cinco Esquinas',
        'Anselmo Llorente',
        'León XIII',
        'Colima',
        'San Vicente',
        'San Jerónimo',
        'Trinidad',
        'San Pedro',
        'Sabanilla',
        'Mercedes o Betania',
        'San Rafael',
        'San Pablo',
        'San Pedro',
        'San Juan de Mata',
        'San Luis',
        'Cárara',
        'Santa María',
        'Jardín',
        'Copey',
        'Curridabat',
        'Granadilla',
        'Sánchez',
        'Tirrases',
        'San Isidro de el General',
        'General',
        'Daniel Flores',
        'Rivas',
        'San Pedro',
        'Platanares',
        'Pejibaye',
        'Cajón',
        'Barú',
        'Río Nuevo',
        'Páramo',
        'San Pablo',
        'San Andrés',
        'Llano Bonito',
        'San Isidro',
        'Santa Cruz',
        'San Antonio',
        'Alajuela',
        'San José',
        'Carrizal',
        'San Antonio',
        'Guácima',
        'San Isidro',
        'Sabanilla',
        'San Rafael',
        'Río Segundo',
        'Desamparados',
        'Turrucares',
        'Tambor',
        'La Garita',
        'Sarapiquí',
        'San Ramón',
        'Santiago',
        'San Juan',
        'Piedades Norte',
        'Piedades Sur',
        'San Rafael',
        'San Isidro',
        'Angeles',
        'Alfaro',
        'Volio',
        'Concepción',
        'Zapotal',
        'San Isidro de Peñas Blancas',
        'Grecia',
        'San Isidro',
        'San José',
        'San Roque',
        'Tacares',
        'Río Cuarto',
        'Puente Piedra',
        'Bolílet',
        'San Mateo',
        'Desmonte',
        'Jesús María',
        'Atenas',
        'Jesús',
        'Mercedes',
        'San Isidro',
        'Concepción',
        'San José',
        'Santa Eulalia',
        'Escobal',
        'Naranjo',
        'San Miguel',
        'San José',
        'Cirrí Sur',
        'San Jerónimo',
        'San Juan',
        'Rosario',
        'Palmares',
        'Zaragoza',
        'Buenos Aires',
        'Santiago',
        'Candelaria',
        'Esquipulas',
        'La Granja',
        'San Pedro',
        'San Juan',
        'San Rafael',
        'Carrillos',
        'Sabana Redonda',
        'Orotina',
        'Mastate',
        'Hacienda Vieja',
        'Coyolar',
        'Ceiba',
        'Quesada',
        'Florencia',
        'Buenavista',
        'Aguas Zarcas',
        'Venecia',
        'Pital',
        'Fortuna',
        'Tigra',
        'Palmera',
        'Venado',
        'Cutris',
        'Monterrey',
        'Pocosol',
        'Laguna',
        'Tapezco',
        'Guadalupe',
        'Palmira',
        'Zapote',
        'Las Brisas',
        'Sarchí Norte',
        'Sarchí Sur',
        'Toro Amarillo',
        'San Pedro',
        'Rodríguez',
        'Upala',
        'Aguas Claras',
        'San José o Pizote',
        'Bijagua',
        'Delicias',
        'Dos Ríos',
        'Yolillal',
        'Los Chiles',
        'Caño Negro',
        'Amparo',
        'San Jorge',
        'San Rafael',
        'Buenavista',
        'Cote',
        'Oriental',
        'Occidental',
        'Carmen',
        'San Nicolás',
        'Aguacaliente o San Francisco',
        'Guadalupe o Arenilla',
        'Corralillo',
        'Tierra Blanca',
        'Dulce Nombre',
        'Llano Grande',
        'Quebradilla',
        'Paraíso',
        'Santiago',
        'Orosi',
        'Cachí',
        'Los Llanos de Santa Lucía',
        'Tres Ríos',
        'San Diego',
        'San Juan',
        'San Rafael',
        'Concepción',
        'Dulce Nombre',
        'San Ramón',
        'Río Azul',
        'Juan Viñas',
        'Tucurrique',
        'Pejibaye',
        'Turrialba',
        'La Suiza',
        'Peralta',
        'Santa Cruz',
        'Santa Teresita',
        'Pavones',
        'Tuis',
        'Tayutic',
        'Santa Rosa',
        'Tres Equis',
        'La Isabel',
        'Chirripó',
        'Pacayas',
        'Cervantes',
        'Capellades',
        'San Rafael',
        'Cot',
        'Potrero Cerrado',
        'Cipreses',
        'Santa Rosa',
        'El Tejar',
        'San Isidro',
        'Tobosi',
        'Patio de Agua',
        'Heredia',
        'Mercedes',
        'San Francisco',
        'Ulloa',
        'letablanca',
        'Barva',
        'San Pedro',
        'San Pablo',
        'San Roque',
        'Santa Lucía',
        'San José de la Montaña',
        'Santo Domingo',
        'San Vicente',
        'San Miguel',
        'Paracito',
        'Santo Tomás',
        'Santa Rosa',
        'Tures',
        'Pará',
        'Santa Bárbara',
        'San Pedro',
        'San Juan',
        'Jesús',
        'Santo Domingo del Roble',
        'Puraba',
        'San Rafael',
        'San Josecito',
        'Santiago',
        'Angeles',
        'Concepción',
        'San Isidro',
        'San José',
        'Concepción',
        'San Francisco',
        'San Antonio',
        'La Ribera',
        'Asunción',
        'San Joaquín',
        'Barrantes',
        'Llorente',
        'San Pablo',
        'Puerto Viejo',
        'La Virgen',
        'Horquetas',
        'Llanuras de Gaspar',
        'Cureña',
        'Liberia',
        'Cañas Dulces',
        'Mayorga',
        'Nacascolo',
        'Curubande',
        'Nicoya',
        'Mansión',
        'San Antonio',
        'Quebrada Honda',
        'Sámara',
        'Nósara',
        'Belén de Nosarita',
        'Santa Cruz',
        'Bolsón',
        'Veintisiete de Abril',
        'Tempate',
        'Cartagena',
        'Cuajiniquil',
        'Diriá',
        'Cabo Velas',
        'Tamarindo',
        'Bagaces',
        'Fortuna',
        'Mogote',
        'Río Naranjo',
        'Filadelfia',
        'Palmira',
        'Sardinal',
        'Belén',
        'Cañas',
        'Palmira',
        'San Miguel',
        'Bebedero',
        'Porozal',
        'Juntas',
        'Sierra',
        'San Juan',
        'Colorado',
        'Tilarán',
        'Quebrada Grande',
        'Tronadora',
        'Santa Rosa',
        'Líbano',
        'Tierras Morenas',
        'Arenal',
        'Carmona',
        'Santa Rita',
        'Zapotal',
        'San Pablo',
        'Porvenir',
        'Bejuco',
        'La Cruz',
        'Santa Cecilia',
        'Garita',
        'Santa Elena',
        'Hojancha',
        'Monte Romo',
        'Puerto Carrillo',
        'Huacas',
        'Puntarenas',
        'Pitahaya',
        'Chomes',
        'Lepanto',
        'Paquera',
        'Manzanillo',
        'Guacimal',
        'Barranca',
        'Monte Verde',
        'Isla del Coco',
        'Cóbano',
        'Chacarita',
        'Chira',
        'Acapulco',
        'Roble',
        'Arancibia',
        'Espíritu Santo',
        'San Juan Grande',
        'Macacona',
        'San Rafael',
        'San Jerónimo',
        'Buenos Aires',
        'Volcán',
        'Potrero Grande',
        'Boruca',
        'Pilas',
        'Colinas o Bajo de Maíz',
        'Chánguena',
        'Bioley',
        'Brunka',
        'Miramar',
        'Unión',
        'San Isidro',
        'Puerto Cortés',
        'Palmar',
        'Sierpe',
        'Bahía Ballena',
        'Piedras Blancas',
        'Quepos',
        'Savegre',
        'Naranjito',
        'Golfito',
        'Puerto Jiménez',
        'Guaycará',
        'Pavon',
        'San Vito',
        'Sabalito',
        'Agua Buena',
        'Limoncito',
        'Pittier',
        'Parrita',
        'Corredor',
        'La Cuesta',
        'Paso Canoas',
        'Laurel',
        'Jacó',
        'Tárcoles',
        'Limón',
        'Valle La Estrella',
        'Río Blanco',
        'Matama',
        'Guápiles',
        'Jiménez',
        'Rita',
        'Roxana',
        'Cariari',
        'Colorado',
        'Siquirres',
        'Pacuarito',
        'Florida',
        'Germania',
        'Cairo',
        'Alegría',
        'Bratsi',
        'Sixaola',
        'Cahuita',
        'Telire',
        'Matina',
        'Batán',
        'Carrandí',
        'Guácimo',
        'Mercedes',
        'Pocora',
        'Río Jiménez',
        'Duacarí'
    ];

    for (let i = 0; i < provincias.length; i++) {
        let opt = document.createElement('option');
        opt.innerHTML = provincias[i];
        opt.value = provincias[i];
        selectProvincias.appendChild(opt);
    }


    this.popularCanton = function () {
        

        $("#inputCanton option").each(function () {
            if (this.value !== '') {
                $(this).remove();
            }
        });
        $("#inputDistrito option").each(function () {
            if (this.value !== '') {
                $(this).remove();
            }
        });
        let valorProvincia = selectProvincias.options[selectProvincias.selectedIndex].text;
        if (valorProvincia == 'San José') {

            for (let i = 0; i < 20; i++) {
                let opt = document.createElement('option');
                opt.innerHTML = cantones[i];
                opt.value = cantones[i];
                selectCantones.appendChild(opt);

            }
        }
        if (valorProvincia == 'Alajuela') {

            for (let i = 20; i < 36; i++) {
                let opt = document.createElement('option');
                opt.innerHTML = cantones[i];
                opt.value = cantones[i];
                selectCantones.appendChild(opt);
            }
        }


        if (valorProvincia == 'Cartago') {

            for (let i = 36; i < 44; i++) {
                let opt = document.createElement('option');
                opt.innerHTML = cantones[i];
                opt.value = cantones[i];
                selectCantones.appendChild(opt);
            }
        }


        if (valorProvincia == 'Heredia') {

            for (let i = 44; i < 54; i++) {
                let opt = document.createElement('option');
                opt.innerHTML = cantones[i];
                opt.value = cantones[i];
                selectCantones.appendChild(opt);
            }
        }

        if (valorProvincia == 'Guanacaste') {

            for (let i = 54; i < 65; i++) {
                let opt = document.createElement('option');
                opt.innerHTML = cantones[i];
                opt.value = cantones[i];
                selectCantones.appendChild(opt);
            }
        }

        if (valorProvincia == 'Puntarenas') {

            for (let i = 65; i < 76; i++) {
                let opt = document.createElement('option');
                opt.innerHTML = cantones[i];
                opt.value = cantones[i];
                selectCantones.appendChild(opt);
            }
        }

        if (valorProvincia == 'Limón') {

            for (let i = 76; i < 82; i++) {
                let opt = document.createElement('option');
                opt.innerHTML = cantones[i];
                opt.value = cantones[i];
                selectCantones.appendChild(opt);
            }
        }

    }

    // Crea los distritos del cantón elegido

    this.popularDistrito = function() {


        $("#inputDistrito option").each(function () {
            if (this.value !== '') {
                $(this).remove();
            }
        });
        let valorProvincia = selectProvincias.options[selectProvincias.selectedIndex].text;
        let valorCanton = selectCantones.options[selectCantones.selectedIndex].text;

        if (valorProvincia == 'San José') {
            if (valorCanton == 'San José') {
                for (let i = 0; i < 11; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Escazú') {
                for (let i = 11; i < 14; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Desamparados') {
                for (let i = 14; i < 27; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Puriscal') {
                for (let i = 27; i < 36; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Tarrazú') {
                for (let i = 36; i < 40; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Aserrí') {
                for (let i = 40; i < 46; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Mora') {
                for (let i = 46; i < 51; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Goicoechea') {
                for (let i = 51; i < 58; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Santa Ana') {
                for (let i = 58; i < 64; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Alajuelita') {
                for (let i = 64; i < 69; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Vasquez de Coronado') {
                for (let i = 69; i < 74; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Acosta') {
                for (let i = 74; i < 79; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Tibás') {
                for (let i = 79; i < 84; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Moravia') {
                for (let i = 84; i < 87; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Montes de Oca') {
                for (let i = 87; i < 91; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Turrubares') {
                for (let i = 91; i < 96; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Dota') {
                for (let i = 96; i < 99; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }

            if (valorCanton == 'Curridabat') {
                for (let i = 99; i < 103; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Pérez Zeledón') {
                for (let i = 103; i < 114; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'León Cortés') {
                for (let i = 114; i < 120; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
        }
        if (valorProvincia == 'Alajuela') {

            if (valorCanton == 'Alajuela') {
                for (let i = 120; i < 134; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'San Ramón') {
                for (let i = 134; i < 147; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Grecia') {
                for (let i = 147; i < 155; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'San Mateo') {
                for (let i = 155; i < 158; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Atenas') {
                for (let i = 158; i < 166; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Naranjo') {
                for (let i = 166; i < 173; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Palmares') {
                for (let i = 173; i < 180; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Poás') {
                for (let i = 180; i < 185; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Orotina') {
                for (let i = 185; i < 190; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'San Carlos') {
                for (let i = 190; i < 203; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Alfaro Ruiz') {
                for (let i = 203; i < 210; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Valverde Vega') {
                for (let i = 210; i < 215; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Upala') {
                for (let i = 215; i < 222; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Los Chiles') {
                for (let i = 222; i < 226; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Guatuso') {
                for (let i = 226; i < 229; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
        }

        if (valorProvincia == 'Cartago') {

            if (valorCanton == 'Cartago') {
                for (let i = 229; i < 240; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Paraíso') {
                for (let i = 240; i < 245; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'La Unión') {
                for (let i = 245; i < 253; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Jiménez') {
                for (let i = 253; i < 256; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Turrialba') {
                for (let i = 256; i < 268; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Alvarado') {
                for (let i = 268; i < 271; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Oreamuno') {
                for (let i = 271; i < 276; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'El Guarco') {
                for (let i = 276; i < 280; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
        }


        if (valorProvincia == 'Heredia') {


            if (valorCanton == 'Heredia') {
                for (let i = 280; i < 285; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Barva') {
                for (let i = 285; i < 291; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }

            if (valorCanton == 'Santo Domingo') {
                for (let i = 291; i < 299; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Santa Bárbara') {
                for (let i = 299; i < 305; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'San Rafael') {
                for (let i = 305; i < 310; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'San Isidro') {
                for (let i = 310; i < 314; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Belén') {
                for (let i = 314; i < 317; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Flores') {
                for (let i = 317; i < 320; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'San Pablo') {
                for (let i = 320; i < 321; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Sarapiquí') {
                for (let i = 321; i < 326; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
        }

        if (valorProvincia == 'Guanacaste') {
            if (valorCanton == 'Liberia') {
                for (let i = 326; i < 331; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Nicoya') {
                for (let i = 331; i < 338; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Santa Cruz') {
                for (let i = 338; i < 347; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Bagaces') {
                for (let i = 347; i < 351; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Carrillo') {
                for (let i = 351; i < 355; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Cañas') {
                for (let i = 355; i < 360; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Abangares') {
                for (let i = 360; i < 364; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Tilarán') {
                for (let i = 364; i < 371; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Nandayure') {
                for (let i = 371; i < 377; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'La Cruz') {
                for (let i = 377; i < 381; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Hojancha') {
                for (let i = 381; i < 385; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
        }

        if (valorProvincia == 'Puntarenas') {
            if (valorCanton == 'Puntarenas') {
                for (let i = 385; i < 401; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Esparza') {
                for (let i = 401; i < 406; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Buenos Aires') {
                for (let i = 406; i < 415; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Montes de Oro') {
                for (let i = 415; i < 418; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Osa') {
                for (let i = 418; i < 423; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Quepos') {
                for (let i = 423; i < 426; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Golfito') {
                for (let i = 426; i < 430; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Coto Brus') {
                for (let i = 430; i < 435; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Parrita') {
                for (let i = 435; i < 436; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Corredores') {
                for (let i = 436; i < 440; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Garabito') {
                for (let i = 440; i < 442; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
        }

        if (valorProvincia == 'Limón') {
            if (valorCanton == 'Limón') {
                for (let i = 442; i < 446; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Pococí') {
                for (let i = 446; i < 452; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Siquirres') {
                for (let i = 452; i < 458; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Talamanca') {
                for (let i = 458; i < 462; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Matina') {
                for (let i = 462; i < 465; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
            if (valorCanton == 'Guácimo') {
                for (let i = 465; i < 470; i++) {
                    let opt = document.createElement('option');
                    opt.innerHTML = distritos[i];
                    opt.value = distritos[i];
                    selectDistrito.appendChild(opt);
                }
            }
        }
    }

    selectProvincias.addEventListener('change', popularCanton);
    selectCantones.addEventListener('change', popularDistrito);
}