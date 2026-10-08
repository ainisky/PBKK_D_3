# Modul Praktikum: Membuat Kalkulator GUI Menggunakan C# Windows Forms

## 1. Tujuan

Modul ini membahas cara membuat aplikasi kalkulator sederhana menggunakan **C#** dan **Windows Forms**. Aplikasi memiliki antarmuka grafis (GUI) dengan:

- Display untuk menampilkan angka dan hasil perhitungan.
- Tombol angka 0–9.
- Operator penjumlahan (`+`).
- Operator pengurangan (`-`).
- Operator perkalian (`*`).
- Operator pembagian (`/`).
- Tombol `=` untuk menjalankan perhitungan.
- Tombol `C` untuk menghapus/reset perhitungan.

Pada implementasinya, UI dibuat langsung menggunakan kode C#, sehingga tidak bergantung pada Windows Forms Designer.

---

## 2. Struktur Dasar Program

Kode menggunakan tiga namespace utama:

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;
```

### `System`

Digunakan untuk fitur dasar C#, seperti:

- `EventArgs`
- tipe data
- operasi dasar program

Pada program ini `System` terutama digunakan untuk menangani event tombol melalui `EventArgs`.

### `System.Drawing`

Digunakan untuk mengatur tampilan komponen GUI, misalnya:

- `Font`
- `Point`

Contoh:

```csharp
display.Font = new Font("Arial", 24);
```

Kode tersebut mengatur font display menjadi Arial dengan ukuran 24.

Contoh lainnya:

```csharp
display.Location = new Point(20, 20);
```

Kode tersebut menentukan posisi display pada window.

### `System.Windows.Forms`

Merupakan namespace utama untuk membuat aplikasi Windows Forms.

Beberapa class yang digunakan:

- `Form`
- `TextBox`
- `Button`
- `MessageBox`
- `HorizontalAlignment`

---

# 3. Class `Form1`

```csharp
public class Form1 : Form
```

`Form1` merupakan class utama yang merepresentasikan window aplikasi kalkulator.

Class tersebut mewarisi (`inherit`) class `Form`.

Dengan inheritance ini, `Form1` mendapatkan berbagai kemampuan dari Windows Forms, seperti:

- memiliki window;
- menambahkan komponen;
- menerima event;
- mengatur ukuran dan posisi window.

Secara sederhana:

```text
Form
  ↓
Form1
  ↓
Kalkulator
```

Karena `Form1` merupakan turunan dari `Form`, objek `Form1` dapat digunakan sebagai window aplikasi.

---

# 4. Variabel Display

```csharp
private TextBox display;
```

Variabel `display` digunakan untuk menyimpan objek `TextBox` yang berfungsi sebagai layar kalkulator.

Display digunakan untuk:

1. menampilkan angka yang diketik;
2. menampilkan hasil perhitungan;
3. menjadi tempat membaca angka yang sedang diproses.

Contoh:

```csharp
display.Text = "0";
```

Artinya display menampilkan angka `0`.

---

# 5. Variabel untuk Proses Perhitungan

Program memiliki tiga variabel utama:

```csharp
private double firstNumber = 0;
private string operation = "";
private bool newNumber = true;
```

## 5.1 `firstNumber`

```csharp
private double firstNumber = 0;
```

Digunakan untuk menyimpan angka pertama dalam operasi.

Contoh pengguna menekan:

```text
10 + 5 =
```

Ketika tombol `+` ditekan:

```text
firstNumber = 10
```

Kemudian angka `5` menjadi angka kedua.

---

## 5.2 `operation`

```csharp
private string operation = "";
```

Digunakan untuk menyimpan operator yang dipilih pengguna.

Contohnya:

```text
+
-
*
/
```

Jika pengguna menekan `+`:

```csharp
operation = "+";
```

Program kemudian mengetahui bahwa operasi yang harus dilakukan adalah penjumlahan.

---

## 5.3 `newNumber`

```csharp
private bool newNumber = true;
```

Variabel ini menentukan apakah angka berikutnya harus:

- menggantikan isi display; atau
- ditambahkan ke angka yang sudah ada.

Contohnya:

Pengguna menekan:

```text
1
```

display menjadi:

```text
1
```

Kemudian menekan:

```text
2
```

display menjadi:

```text
12
```

Namun setelah pengguna menekan operator:

```text
12 +
```

program mengatur:

```csharp
newNumber = true;
```

Ketika pengguna kemudian menekan `5`, angka `5` akan menggantikan isi display sebelumnya.

---

# 6. Constructor

```csharp
public Form1()
{
    CreateCalculatorUI();
}
```

Constructor adalah method yang dipanggil ketika objek `Form1` dibuat.

Pada program ini constructor memanggil:

```csharp
CreateCalculatorUI();
```

Tujuannya adalah membuat seluruh tampilan kalkulator ketika aplikasi dijalankan.

Alurnya:

```text
Program mulai
     ↓
Form1 dibuat
     ↓
Constructor dijalankan
     ↓
CreateCalculatorUI()
     ↓
Window + display + tombol dibuat
```

---

# 7. Membuat Window

Method:

```csharp
private void CreateCalculatorUI()
```

digunakan untuk membuat antarmuka kalkulator.

Bagian pertama:

```csharp
this.Text = "Kalkulator";
this.Width = 350;
this.Height = 500;
this.StartPosition = FormStartPosition.CenterScreen;
```

## `this.Text`

```csharp
this.Text = "Kalkulator";
```

Menentukan judul window.

Hasilnya, title bar aplikasi akan menampilkan:

```text
Kalkulator
```

## `this.Width`

```csharp
this.Width = 350;
```

Menentukan lebar window sebesar 350 pixel.

## `this.Height`

```csharp
this.Height = 500;
```

Menentukan tinggi window sebesar 500 pixel.

## `StartPosition`

```csharp
this.StartPosition = FormStartPosition.CenterScreen;
```

Menentukan posisi awal window berada di tengah layar.

---

# 8. Membuat Display

Display dibuat menggunakan:

```csharp
display = new TextBox();
```

Kemudian beberapa property diatur:

```csharp
display.Text = "0";
display.Font = new Font("Arial", 24);
display.TextAlign = HorizontalAlignment.Right;
display.ReadOnly = true;
```

## Nilai awal

```csharp
display.Text = "0";
```

Ketika kalkulator pertama kali dibuka, display menunjukkan `0`.

## Font

```csharp
display.Font = new Font("Arial", 24);
```

Menggunakan:

- font: Arial
- ukuran: 24

## Perataan teks

```csharp
display.TextAlign = HorizontalAlignment.Right;
```

Angka ditampilkan di sebelah kanan, seperti kalkulator pada umumnya.

## ReadOnly

```csharp
display.ReadOnly = true;
```

Pengguna tidak mengetik langsung ke display.

Angka hanya dapat dimasukkan melalui tombol kalkulator.

---

# 9. Ukuran dan Posisi Display

```csharp
display.Width = 290;
display.Height = 50;
display.Location = new Point(20, 20);
```

Ukuran display:

```text
Lebar  = 290
Tinggi = 50
```

Posisinya:

```text
X = 20
Y = 20
```

Secara visual:

```text
Window
┌──────────────────────────────┐
│  ┌────────────────────────┐  │
│  │                    123 │  │
│  └────────────────────────┘  │
│                              │
│                              │
└──────────────────────────────┘
```

---

# 10. Menambahkan Display ke Window

```csharp
this.Controls.Add(display);
```

`Controls` merupakan kumpulan komponen yang terdapat pada window.

Dengan:

```csharp
Controls.Add()
```

komponen dimasukkan ke dalam window.

Tanpa kode tersebut, display sudah dibuat tetapi tidak akan terlihat pada window.

---

# 11. Membuat Daftar Tombol

Program menggunakan array dua dimensi:

```csharp
string[,] buttons =
{
    { "7", "8", "9", "/" },
    { "4", "5", "6", "*" },
    { "1", "2", "3", "-" },
    { "0", "C", "=", "+" }
};
```

Array tersebut menggambarkan susunan tombol.

Strukturnya:

```text
7   8   9   /
4   5   6   *
1   2   3   -
0   C   =   +
```

Array dua dimensi memudahkan program membuat tombol menggunakan perulangan.

---

# 12. Mengatur Posisi Tombol

```csharp
int startX = 20;
int startY = 100;

int buttonWidth = 65;
int buttonHeight = 60;
int gap = 10;
```

Variabel tersebut digunakan untuk menentukan layout.

### `startX`

```csharp
int startX = 20;
```

Posisi horizontal awal tombol.

### `startY`

```csharp
int startY = 100;
```

Posisi vertikal awal tombol.

### Ukuran tombol

```csharp
int buttonWidth = 65;
int buttonHeight = 60;
```

Setiap tombol memiliki ukuran:

```text
65 × 60 pixel
```

### `gap`

```csharp
int gap = 10;
```

Jarak antar tombol adalah 10 pixel.

---

# 13. Membuat Tombol dengan Nested Loop

```csharp
for (int row = 0; row < 4; row++)
{
    for (int col = 0; col < 4; col++)
    {
        ...
    }
}
```

Digunakan dua buah `for` karena array tombol memiliki:

- 4 baris
- 4 kolom

Strukturnya:

```text
row 0 → 7  8  9  /
row 1 → 4  5  6  *
row 2 → 1  2  3  -
row 3 → 0  C  =  +
```

`row` menentukan baris.

`col` menentukan kolom.

---

# 14. Membuat Objek Button

Di dalam loop:

```csharp
Button button = new Button();
```

Setiap iterasi membuat satu objek `Button`.

Kemudian teks tombol ditentukan:

```csharp
button.Text = buttons[row, col];
```

Contoh ketika:

```text
row = 0
col = 0
```

maka:

```csharp
buttons[0,0]
```

berisi:

```text
7
```

Sehingga tombol tersebut memiliki teks `7`.

---

# 15. Mengatur Tampilan Tombol

```csharp
button.Font = new Font("Arial", 16);
```

Mengatur font tombol menjadi Arial ukuran 16.

Ukuran tombol:

```csharp
button.Width = buttonWidth;
button.Height = buttonHeight;
```

Nilainya:

```text
65 × 60 pixel
```

---

# 16. Menentukan Posisi Tombol

```csharp
button.Location = new Point(
    startX + col * (buttonWidth + gap),
    startY + row * (buttonHeight + gap)
);
```

Bagian ini menghitung posisi tombol secara otomatis.

Koordinat X:

```text
startX + col × (buttonWidth + gap)
```

Koordinat Y:

```text
startY + row × (buttonHeight + gap)
```

Misalnya tombol pertama:

```text
row = 0
col = 0
```

maka:

```text
X = 20
Y = 100
```

Tombol kedua:

```text
row = 0
col = 1
```

maka:

```text
X = 20 + 1 × (65 + 10)
X = 95
```

Dengan cara tersebut tombol tersusun secara otomatis.

---

# 17. Event Tombol

Bagian penting berikutnya:

```csharp
button.Click += Button_Click;
```

Kode ini menghubungkan event `Click` tombol dengan method:

```csharp
Button_Click
```

Artinya, ketika pengguna menekan tombol apa pun, method:

```csharp
Button_Click()
```

akan dijalankan.

Konsep ini disebut **event handling**.

Alurnya:

```text
User klik tombol
       ↓
Button.Click
       ↓
Button_Click()
       ↓
Program menentukan tombol
       ↓
Angka / Operator / = / C
```

---

# 18. Method `Button_Click`

```csharp
private void Button_Click(object sender, EventArgs e)
```

Method ini menangani semua tombol kalkulator.

Parameter:

### `sender`

```csharp
object sender
```

Berisi objek yang menghasilkan event.

Dalam kasus ini, objek tersebut adalah tombol yang diklik.

Kemudian:

```csharp
Button button = (Button)sender;
```

mengubah `sender` menjadi objek `Button`.

---

# 19. Mengambil Nilai Tombol

```csharp
string value = button.Text;
```

Digunakan untuk mendapatkan teks tombol.

Misalnya pengguna menekan tombol:

```text
7
```

maka:

```csharp
value = "7";
```

Jika menekan:

```text
+
```

maka:

```csharp
value = "+";
```

Program kemudian menentukan tindakan berdasarkan nilai tersebut.

---

# 20. Memproses Tombol Angka

```csharp
if (double.TryParse(value, out _))
```

Digunakan untuk memeriksa apakah nilai tombol dapat dianggap sebagai angka.

Contoh:

```text
"7" → angka
"5" → angka
"0" → angka
"+" → bukan angka
"C" → bukan angka
```

`TryParse()` tidak langsung menyebabkan error ketika string bukan angka.

---

# 21. Kondisi `newNumber`

```csharp
if (display.Text == "0" || newNumber)
{
    display.Text = value;
    newNumber = false;
}
else
{
    display.Text += value;
}
```

Ada dua kondisi.

### Kondisi pertama

```csharp
display.Text == "0"
```

Jika display masih `0`, angka baru menggantikan `0`.

Contoh:

```text
0
↓ tekan 5
5
```

### Kondisi kedua

```csharp
newNumber == true
```

Artinya program sedang menunggu angka baru setelah operator.

Contoh:

```text
10 + 5
```

Setelah `+` ditekan:

```csharp
newNumber = true;
```

Ketika `5` ditekan, display berubah menjadi:

```text
5
```

bukan:

```text
105
```

---

# 22. Menambahkan Angka ke Display

Jika tidak memenuhi kondisi sebelumnya:

```csharp
else
{
    display.Text += value;
}
```

Angka ditambahkan ke angka sebelumnya.

Contoh:

```text
Tekan 1
→ 1

Tekan 2
→ 12

Tekan 5
→ 125
```

---

# 23. Memproses Operator

Operator diperiksa dengan:

```csharp
else if (value == "+" ||
         value == "-" ||
         value == "*" ||
         value == "/")
```

Jika tombol merupakan salah satu operator, program menjalankan blok ini.

Kemudian:

```csharp
firstNumber = double.Parse(display.Text);
```

Angka pada display disimpan sebagai angka pertama.

Contoh:

```text
25 + 
```

maka:

```text
firstNumber = 25
```

Kemudian operator disimpan:

```csharp
operation = value;
```

Jika tombol `+` ditekan:

```text
operation = "+"
```

Jika tombol `*` ditekan:

```text
operation = "*"
```

Setelah itu:

```csharp
newNumber = true;
```

menandakan bahwa angka berikutnya merupakan angka baru.

---

# 24. Tombol `=`

Bagian:

```csharp
else if (value == "=")
```

dijalankan ketika pengguna menekan tombol sama dengan.

Pertama, angka kedua diambil:

```csharp
double secondNumber = double.Parse(display.Text);
```

Contoh:

```text
10 + 5 =
```

maka:

```text
firstNumber  = 10
secondNumber = 5
operation    = "+"
```

---

# 25. Variabel Result

```csharp
double result = 0;
```

Variabel `result` digunakan untuk menyimpan hasil akhir operasi.

Kemudian program menggunakan `switch`.

---

# 26. Switch untuk Operasi

```csharp
switch (operation)
{
    case "+":
        result = firstNumber + secondNumber;
        break;

    case "-":
        result = firstNumber - secondNumber;
        break;

    case "*":
        result = firstNumber * secondNumber;
        break;

    case "/":
        result = firstNumber / secondNumber;
        break;
}
```

`switch` memeriksa operator yang sebelumnya disimpan.

## Penjumlahan

```csharp
case "+":
    result = firstNumber + secondNumber;
    break;
```

Contoh:

```text
10 + 5 = 15
```

## Pengurangan

```csharp
case "-":
    result = firstNumber - secondNumber;
    break;
```

Contoh:

```text
10 - 5 = 5
```

## Perkalian

```csharp
case "*":
    result = firstNumber * secondNumber;
    break;
```

Contoh:

```text
10 * 5 = 50
```

## Pembagian

```csharp
case "/":
    result = firstNumber / secondNumber;
    break;
```

Contoh:

```text
10 / 5 = 2
```

---

# 27. Mencegah Pembagian dengan Nol

Sebelum melakukan pembagian, program memeriksa:

```csharp
if (secondNumber == 0)
```

Jika angka kedua adalah `0`, program menampilkan:

```csharp
MessageBox.Show(
    "Tidak dapat membagi dengan 0!",
    "Error"
);
```

Kemudian:

```csharp
return;
```

digunakan untuk menghentikan proses perhitungan.

Contoh:

```text
10 / 0
```

akan menghasilkan pesan error:

```text
Tidak dapat membagi dengan 0!
```

---

# 28. Menampilkan Hasil

Setelah perhitungan selesai:

```csharp
display.Text = result.ToString();
```

Hasil bertipe `double` diubah menjadi `string` agar dapat ditampilkan pada `TextBox`.

Contoh:

```text
result = 15
```

menjadi:

```text
display.Text = "15"
```

Kemudian:

```csharp
newNumber = true;
```

menandakan bahwa input berikutnya dapat dianggap sebagai angka baru.

---

# 29. Tombol Clear (`C`)

Bagian terakhir:

```csharp
else if (value == "C")
```

digunakan untuk mereset kalkulator.

```csharp
display.Text = "0";
firstNumber = 0;
operation = "";
newNumber = true;
```

Semua state kalkulator dikembalikan ke kondisi awal.

Sebelum `C`:

```text
firstNumber = 25
operation = "+"
display = 10
```

Setelah `C`:

```text
firstNumber = 0
operation = ""
display = 0
newNumber = true
```

---

# 30. Alur Lengkap Perhitungan

Misalnya pengguna melakukan:

```text
12 + 8 =
```

Alurnya:

```text
1. Tekan 1
   display = "1"

2. Tekan 2
   display = "12"

3. Tekan +
   firstNumber = 12
   operation = "+"
   newNumber = true

4. Tekan 8
   display = "8"
   newNumber = false

5. Tekan =
   secondNumber = 8

   operation = "+"

   result = 12 + 8

   result = 20

6. Display
   display = "20"
```

Secara keseluruhan:

```text
Input angka
     ↓
Display
     ↓
Operator
     ↓
Simpan firstNumber
     ↓
Input angka kedua
     ↓
Tekan =
     ↓
Hitung berdasarkan operator
     ↓
Tampilkan result
```

---

# 31. Konsep C# yang Digunakan

Program ini menerapkan beberapa konsep penting dalam C#.

## 31.1 Class dan Object

```csharp
public class Form1 : Form
```

`Form1` merupakan class.

Sedangkan:

```csharp
Button button = new Button();
```

membuat object dari class `Button`.

---

## 31.2 Inheritance

```csharp
public class Form1 : Form
```

Menunjukkan bahwa `Form1` mewarisi `Form`.

Ini merupakan konsep **inheritance** pada OOP.

---

## 31.3 Encapsulation

Variabel dibuat sebagai:

```csharp
private
```

Contoh:

```csharp
private double firstNumber;
private string operation;
private bool newNumber;
```

Artinya data tersebut hanya digunakan di dalam class `Form1`.

---

## 31.4 Event Handling

```csharp
button.Click += Button_Click;
```

Menghubungkan event klik tombol dengan method tertentu.

Ketika tombol diklik:

```text
Click Event
    ↓
Button_Click()
```

---

## 31.5 Array Dua Dimensi

```csharp
string[,] buttons
```

Digunakan untuk menyimpan struktur tombol kalkulator dalam bentuk baris dan kolom.

---

## 31.6 Perulangan

```csharp
for
```

Digunakan untuk membuat 16 tombol tanpa menulis kode tombol satu per satu.

---

## 31.7 Percabangan

Program menggunakan:

```csharp
if
else if
else
```

untuk menentukan apakah tombol merupakan:

- angka;
- operator;
- `=`;
- `C`.

Program juga menggunakan:

```csharp
switch
```

untuk menentukan operasi matematika.

---

# 32. Kesimpulan

Program kalkulator ini menggunakan **C# Windows Forms** untuk membangun aplikasi GUI sederhana. Antarmuka dibuat secara programatik menggunakan `Form`, `TextBox`, dan `Button`.

Logika kalkulator menggunakan tiga state utama:

```text
firstNumber
operation
newNumber
```

Ketika tombol diklik, event `Button_Click()` menentukan jenis input dan melakukan tindakan yang sesuai.

Dengan pendekatan ini, aplikasi sudah memiliki:

- GUI;
- input angka;
- operasi aritmatika;
- validasi pembagian dengan nol;
- tombol reset;
- event handling;
- penggunaan class dan object;
- inheritance;
- encapsulation;
- array;
- looping;
- conditional statement;
- switch statement.

Struktur program juga memisahkan proses pembuatan UI melalui:

```csharp
CreateCalculatorUI()
```

dan proses penanganan input melalui:

```csharp
Button_Click()
```

sehingga kode lebih mudah dipahami dan dikembangkan.

## 33. Dokumentasi Hasil
<img width="323" height="484" alt="image" src="https://github.com/user-attachments/assets/e33bca02-1e29-4f5f-a8a8-7ae12e731498" />
<img width="323" height="480" alt="image" src="https://github.com/user-attachments/assets/852a5622-218a-4df4-a178-5edc977fc977" />
