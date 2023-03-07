CREATE TABLE
  users (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    name varchar(255) NOT NULL,
    email varchar(255) NOT NULL,
    password_hash char(60) NOT NULL,
    type VARCHAR(20) NOT NULL CHECK (type IN ('customer', 'manager')),
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW()
  );

CREATE TABLE
  addresses (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    customer_id uuid NOT NULL,
    state varchar(255) NOT NULL,
    city varchar(50) NOT NULL,
    neighborhood varchar(50) NOT NULL CHECK (
      neighborhood IN (
        'Alto da Brasília',
        'Alto do Cristo',
        'Antônio Carlos Belchior',
        'Betânia',
        'Campo dos Velhos',
        'Parque Alvorada',
        'Centro',
        'Cidade Dr José Euclides Ferreira Gomes',
        'Terrenos Novos',
        'Cidade Pedro Mendes Carneiro',
        'Cohab III',
        'Cohab I',
        'Cohab II',
        'Coração de Jesus',
        'Distrito Industrial',
        'Dom José',
        'Alto Novo',
        'Dom Expedito',
        'Feitosa',
        'Domingos Olímpio',
        'Expectativa',
        'Jatobá',
        'Jerônimo de Medeiros Prado',
        'Jocely Dantas de Andrade Torres',
        'Junco',
        'Juvêncio de Andrade',
        'Novo Recanto',
        'Padre Ibiapina',
        'Padre Palhano',
        'Nova Caiçara',
        'Cidade Gerardo Cristino de Menezes',
        'Parque Silvana',
        'Pedrinhas',
        'Edmundo Monte Coelho',
        'Nossa Senhora de Fátima',
        'Juazeiro',
        'Renato Parente',
        'Sinhá Sabóia',
        'Várzea Grande',
        'Vila União',
        'Sumaré'
      )
    ),
    street varchar(255) NOT NULL,
    street_number varchar(255) NOT NULL,
    complement varchar(255) NOT NULL,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW(),
    FOREIGN KEY (customer_id) REFERENCES users(id)
  );

CREATE TABLE
  orders (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    customer_id uuid NOT NULL,
    address_id uuid NOT NULL,
    status VARCHAR(20) NOT NULL CHECK (
      status IN ('pendente', 'sendo feito', 'à caminho', 'entregue')
    ),
    delivery_fee numeric NOT NULL,
    final_price numeric NOT NULL,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW(),
    FOREIGN KEY (customer_id) REFERENCES users(id),
    FOREIGN KEY (address_id) REFERENCES addresses(id)
  );

CREATE TABLE
  meals (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    name varchar(255) NOT NULL,
    ingredients varchar(255) NOT NULL,
    price numeric NOT NULL,
    type VARCHAR(20) NOT NULL CHECK (type IN ('pequena', 'media', 'grande')),
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW()
  );

CREATE TABLE
  orders_meals (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    meal_id uuid NOT NULL,
    order_id uuid NOT NULL,
    meal_amount int NOT NULL,
    meal_price numeric NOT NULL,
    discount numeric NOT NULL,
    total_price numeric NOT NULL,
    created_at TIMESTAMP DEFAULT NOW(),
    updated_at TIMESTAMP DEFAULT NOW()
  );