using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        const string output_dir = "midi_silent";

        static void Main(string[] args)
        {

            if (Directory.Exists(output_dir))
                Directory.Delete(output_dir,true);

            Directory.CreateDirectory(output_dir);
            
            foreach(string f in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.mid"))
            {
                MakeSilent(Path.GetFileName(f));
            }

        }

        private static void MakeSilent(string midifile)
        {
            var mf = new MidiFile(midifile, false);

            var timeSignature = mf.Events[0].OfType<TimeSignatureEvent>().FirstOrDefault();


            MidiEventCollection collection = new MidiEventCollection(mf.FileFormat, mf.DeltaTicksPerQuarterNote);

            for (int n = 0; n < mf.Tracks; n++)
            {
                collection.AddTrack();
                foreach (var midiEvent in mf.Events[n])
                {
                    collection.AddEvent(midiEvent, n);

                    if (midiEvent.CommandCode == MidiCommandCode.NoteOn)
                    {
                        var ne = (NoteEvent)midiEvent;
                        ne.Velocity = 1;
                        collection.AddEvent((MidiEvent)ne, n);

                    }
                }
            }

            MidiFile.Export(output_dir + "\\" + midifile, collection);

            Console.WriteLine("Created " + output_dir + "\\" + midifile);

        }
    }
    
}
