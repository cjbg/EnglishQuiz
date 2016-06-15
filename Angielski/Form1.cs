using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Angielski.Properties;

namespace Angielski
{
  public partial class Form1 : Form
  {
    private int _repetitionNumber = 1;
    private Dictionary<string, Word> _wordsAngPol;
    private Dictionary<string, Word> _wordsPolAng;

    public Form1()
    {
      InitializeComponent();
      ReadTxtFile(Resources.unit17_1);
    }

    private void ReadTxtFile(string resourceName)
    {
      List<string> words = ReadWords(resourceName);

      _wordsAngPol = new Dictionary<string, Word>();
      _wordsPolAng = new Dictionary<string, Word>();

      AddWordsToDictionaries(words);
    }

    private void AddWordsToDictionaries(List<string> words)
    {
      for (int i = 0; i < words.Count - 1; i += 2)
      {
        _wordsAngPol.Add(words[i].Trim(),
          new Word { WordName = words[i + 1].Trim(), RepetitionNumber = _repetitionNumber });
        _wordsPolAng.Add(words[i + 1].Trim(),
          new Word { WordName = words[i].Trim(), RepetitionNumber = _repetitionNumber });
      }
    }

    private static List<string> ReadWords(string resourceData)
    {
      return resourceData
        .Split(new[] { Environment.NewLine, ":" }, StringSplitOptions.RemoveEmptyEntries)
        .ToList();
    }

    private void ReadTextFileWithFiltering(string resourceName)
    {
      List<string> words = ReadWords(resourceName);

      _wordsAngPol = new Dictionary<string, Word>();
      _wordsPolAng = new Dictionary<string, Word>();

      AddWordsToDictionariesWithFiltering(words);
    }

    private void ReadTest(string resourceData)
    {
      List<string> words = resourceData
        .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .ToList();

      foreach (var word in words)
      {
        if (word.Count(x => x == ':') == 2)
        {
          throw new Exception(word);
        }
      }
    }

    private void AddWordsToDictionariesWithFiltering(List<string> words)
    {
      for (int i = 0; i < words.Count - 1; i += 2)
      {
        if (DictionariesNotContains(words, i))
        {
          _wordsAngPol.Add(
                words[i].Trim(),
                new Word
                {
                  WordName = words[i + 1].Trim(),
                  RepetitionNumber = _repetitionNumber
                });

          _wordsPolAng.Add(
            words[i + 1].Trim(),
            new Word
            {
              WordName = words[i].Trim(),
              RepetitionNumber = _repetitionNumber
            });
        }
      }
    }

    private bool DictionariesNotContains(List<string> words, int i)
    {
      return !_wordsAngPol.ContainsKey(words[i].Trim())
                && !_wordsPolAng.ContainsKey(words[i + 1].Trim());
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Form2 form = new Form2(_wordsAngPol, _repetitionNumber);
      form.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Form2 form = new Form2(_wordsPolAng, _repetitionNumber);
      form.ShowDialog();
    }

    private void buttonUnit7_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit7);
      labelUnit.Text = "unit 7";
    }

    private void button3_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit8);
      labelUnit.Text = "unit 8";
    }

    private void button4_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit9);
      labelUnit.Text = "unit 9";
    }

    private void button5_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit10);
      labelUnit.Text = "unit 10";
    }

    private void button6_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit11);
      labelUnit.Text = "unit 11";
    }

    private void textBox1_Leave(object sender, EventArgs e)
    {
      try
      {
        _repetitionNumber = Convert.ToInt32(textBox1.Text);
        foreach (KeyValuePair<string, Word> word in _wordsAngPol)
        {
          word.Value.RepetitionNumber = _repetitionNumber;
        }

        foreach (KeyValuePair<string, Word> word in _wordsPolAng)
        {
          word.Value.RepetitionNumber = _repetitionNumber;
        }
      }
      catch (Exception)
      {
        MessageBox.Show(Resources.Form1_textBox1_TextChanged_Zła_wartość);
      }
    }

    private void buttonUnit1_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit1);
      labelUnit.Text = "unit 1";
    }

    private void buttonUnit2_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit2);
      labelUnit.Text = "unit 2";
    }

    private void buttonUnit3_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit3);
      labelUnit.Text = "unit 3";
    }

    private void buttonUnit4_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit4);
      labelUnit.Text = "unit 4";

    }

    private void buttonUnit5_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit5);
      labelUnit.Text = "unit 5";
    }

    private void buttonUnit6_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit6);
      labelUnit.Text = "unit 6";
    }

    private void buttonUnit12_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Już jest kotku ;*");
      ReadTxtFile(Resources.unit12);
      labelUnit.Text = "unit 12";
    }

    private void buttonUnit13_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Nowe unity Mysza :***");
      ReadTxtFile(Resources.unit13);
      labelUnit.Text = "unit 13";
    }

    private void buttonUnit14_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Nowe unity Mysza :***");
      ReadTxtFile(Resources.unit14);
      labelUnit.Text = "unit 14";
    }

    private void buttonUnit15_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Nowe unity Mysza :***");
      ReadTxtFile(Resources.unit15);
      labelUnit.Text = "unit 15";
    }

    private void buttonUnit16_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit16);
      labelUnit.Text = "unit 16";
    }

    private void button7_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit17_1);
      labelUnit.Text = "unit 17 część 1";
    }

    private void button8_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit19_1);
      labelUnit.Text = "unit 19 część 1";
    }

    private void button9_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit17_2);
      labelUnit.Text = "unit 17 część 2";
    }

    private void button10_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit19_2);
      labelUnit.Text = "unit 19 część 2";
    }

    private void button11_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit19_3);
      labelUnit.Text = "unit 19 część 3";
    }

    private void button12_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit20);
      labelUnit.Text = "unit 20";
    }

    private void button13_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit25);
      labelUnit.Text = "unit 25";
    }

    private void button14_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.Unit24);
      labelUnit.Text = "unit 24";
    }

    private void button15_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit23);
      labelUnit.Text = "unit 23";
    }

    private void button16_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit22);
      labelUnit.Text = "unit 22";
    }

    private void button17_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.Unit21);
      labelUnit.Text = "unit 21";
    }

    private void button18_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit20cz2);
      labelUnit.Text = "unit 20 cz2";
    }

    private void button19_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit18);
      labelUnit.Text = "unit 18";
    }

    private void button20_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.unit18_questions);
      labelUnit.Text = "unit 18 pytania";
    }

    private void button21_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book_2_unit1);
      labelUnit.Text = "Książka 2 - Unit 1";
    }

    private void button22_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book_2_unit2);
      labelUnit.Text = "Książka 2 - Unit 2";
    }

    private void button23_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book2_unit3);
      labelUnit.Text = "Książka 2 - Unit 3";
    }

    private void button24_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book_2_unit4);
      labelUnit.Text = "Książka 2 - Unit 4";
    }

    private void button25_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book_2_unit5);
      labelUnit.Text = "Książka 2 - Unit 5";
    }

    private void button26_Click(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book_2_unit6);
      labelUnit.Text = "Książka 2 - Unit 6";
    }

    private void button27_Click_1(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book_2_unit11);
      labelUnit.Text = "Książka 2 - Unit 11";
    }

    private void button28_Click_1(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book_2_unit12);
      labelUnit.Text = "Książka 2 - Unit 12";
    }

    private void button29_Click_1(object sender, EventArgs e)
    {
      ReadTxtFile(Resources.book_2_unit16);
      labelUnit.Text = "Książka 2 - Unit 16";
    }

    private void buttonAll_Click(object sender, EventArgs e)
    {
      ReadTextFileWithFiltering(Resources.English_All);
      //ReadTest(Resources.English_All);

      labelUnit.Text = "Wszystko";
    }

    private void buttonTest_Click(object sender, EventArgs e)
    {
      ReadTextFileWithFiltering(Resources.Test);
      labelUnit.Text = "Test";
    }
  }
}
