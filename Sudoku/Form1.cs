namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            crearCeldas();

            nuevaPartida();
        }

        Celdas[,] celdas = new Celdas[9, 9];
        int cantCeldasVacias = 0;

        private void crearCeldas()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Se crean 81 celdas con estilos y ubicaciones según el índice.
                    celdas[i, j] = new Celdas();
                    celdas[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    celdas[i, j].Size = new Size(45, 45);
                    celdas[i, j].ForeColor = SystemColors.ControlDarkDark;
                    celdas[i, j].Location = new Point(i * 45, j * 45);
                    celdas[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    celdas[i, j].FlatStyle = FlatStyle.Flat;
                    celdas[i, j].FlatAppearance.BorderColor = Color.Black;
                    celdas[i, j].X = i;
                    celdas[i, j].Y = j;

                    // Asignar evento de pulsación de tecla para cada celda.
                    celdas[i, j].KeyPress += cell_keyPressed;

                    panel1.Controls.Add(celdas[i, j]);
                }
            }


        }

        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as Celdas;

            // No hace nada si la celda esta bloqueada.
            if (cell.IsLocked)
                return;

            int value;

            // Agregua el valor de la tecla presionada en la celda solo si es un número
            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                // Limpia el valor de la celda si la tecla presionada es cero.
                // Ya que solo permite numeros del 1 al 9.
                if (value == 0)
                    cell.Clear();
                else
                    cell.Text = value.ToString();

                cell.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void nuevaPartida()
        {
            cargarValores();
            ActivarInactivarBotones(true);

            var cantValoresOcultos = 0;

            // Asigna las celdas disponibles según el nivel elegido.
            if (rbtnPrincipiante.Checked)
                cantValoresOcultos = 45;
            else if (rbtnIntermedio.Checked)
                cantValoresOcultos = 30;
            else if (rbtnExperto.Checked)
                cantValoresOcultos = 15;

            mostrarValoresRandom(cantValoresOcultos);
            cantCeldasVacias = celdas.Cast<Celdas>().Where(x => x.Text.Trim() == string.Empty).ToList().Count();

        }

        private void mostrarValoresRandom(int cantValoresOcultos)
        {
            // Muestra el valor en celdas aleatorias.
            for (int i = 0; i < cantValoresOcultos; i++)
            {
                var rX = random.Next(9);
                var rY = random.Next(9);

                //Elije las celdas de manera aleatoria y bloquee la celda para que el jugador no pueda editar el valor.
                celdas[rX, rY].Text = celdas[rX, rY].Value.ToString();
                celdas[rX, rY].ForeColor = Color.Black;
                celdas[rX, rY].IsLocked = true;

            }
        }

        private void cargarValores()
        {
            // Limpia los valores en cada celda.
            foreach (var cell in celdas)
            {
                cell.Value = 0;
                cell.Clear();
            }

            // Este método se llamará de forma recursiva hasta que encuentre valores adecuados
            // para cada celda.
            buscarProximoValorEnCelda(0, -1);

        }

        Random random = new Random();

        private bool buscarProximoValorEnCelda(int i, int j)
        {
            // Incrementa los valores i y j para pasar a la siguiente celda y,
            // si la columna termina, pase a la siguiente fila
            if (++j > 8)
            {
                j = 0;

                // Finaliza si se acaba la fila
                if (++i > 8)
                    return true;
            }

            var value = 0;
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Encuentra un número aleatorio y válido para la celda, se dirige a la siguiente celda y
            // verifique si se le puede asignar otro número aleatorio y que sea válido.
            do
            {
                // Si no quedan números en la lista para intentar a continuación,
                // regresa a la celda anterior y asígnele un número diferente.
                if (numsLeft.Count < 1)
                {
                    celdas[i, j].Value = 0;
                    return false;
                }

                // Tome un número aleatorio de los números que quedan en la lista
                value = numsLeft[random.Next(0, numsLeft.Count)];
                celdas[i, j].Value = value;

                // Elimina el valor asignado de la lista
                numsLeft.Remove(value);
            }
            while (!verificarNumero(value, i, j) || !buscarProximoValorEnCelda(i, j));

            return true;
        }

        private bool verificarNumero(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                // Verifica todas las celdas de manera vertical.
                if (i != y && celdas[x, i].Value == value)
                    return false;

                // Verifica todas las celdas de manera horizontal.
                if (i != x && celdas[i, y].Value == value)
                    return false;
            }

            // Verfica toda las celdas disponibles.
            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && celdas[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            var celdasErroneas = new List<Celdas>();
            var mensaje = string.Empty;

            // Busca los valores que esten incorrectos.
            foreach (var cell in celdas)
            {
                if (!string.Equals(cell.Value.ToString(), cell.Text))
                    celdasErroneas.Add(cell);
                else
                    cell.IsLocked = true;
            }

            // Verifica el estado de la partida, si el jugador ya inició, errores que tenga o si el jugador ganó.
            if (celdasErroneas.Where(x => x.Text.Trim() != string.Empty).Any())
            {
                // Resalta las celdas que tengan un valor incorrecto.
                celdasErroneas.ForEach(x => x.ForeColor = Color.Red);
                mensaje = "Los valores colocados no son correctos!";
            }
            //else if (wrongCells.All(x => x.Text.Trim() == string.Empty))
            else if (cantCeldasVacias == celdasErroneas.Count())
            {
                mensaje = "Aún no ha empezado su partida!";
            }
            else if (celdasErroneas.Count() == 0)
            {
                mensaje = "Felicidades, usted ha ganado!";

                //Activa o inactiva botones según sea el caso.
                ActivarInactivarBotones(false);
            }

            if (mensaje != string.Empty) MessageBox.Show(mensaje);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (var cell in celdas)
            {
                // Limpia el valor de todas las celdas que no estén bloqueadas.
                if (cell.IsLocked == false)
                    cell.Clear();
            }
        }

        private void btnNuevaPartida_Click(object sender, EventArgs e)
            => nuevaPartida();

        private void btnSolucionar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea finalizar la partida y ver la solución?", "Finalizar Partida", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        var cell = celdas[i, j];
                        if (cell.Text.Trim() == string.Empty)
                        {
                            var value = cell.Value.ToString();
                            //cell.Text = value.ToString();

                            celdas[i, j].Text = value; // cells[i, j].Value.ToString();
                            celdas[i, j].ForeColor = Color.Red;
                            celdas[i, j].IsLocked = true;
                        }
                    }
                }
                //Activa o inactiva botones según sea el caso.
                ActivarInactivarBotones(false);
            }

        }

        private void ActivarInactivarBotones(bool activar)
        {
            btnSolucionar.Enabled = activar;
            btnVerificar.Enabled = activar;
            btnLimpiar.Enabled = activar;
        }
    }
}
