using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace RSP125
{
        /// <summary>
        /// ADC Channels
        /// </summary>
        class ADC
        {
            /// <summary>
            /// Analog input channel0 (pin PA6)
            /// <para>Note: PA6 is also used by the DAC and LCD controller</para>
            /// </summary>
            public const Cpu.AnalogChannel Channel0_PA6 = Cpu.AnalogChannel.ANALOG_0;
            /// <summary>
            /// Analog input channel1 (pin PA7)
            /// </summary>
            public const Cpu.AnalogChannel Channel1_PA7 = Cpu.AnalogChannel.ANALOG_1;
            /// <summary>
            /// Analog input channel2 (pin PC1)
            /// <para>Note: PC1 is also used by the DAC and LCD controller</para>
            /// </summary>
            public const Cpu.AnalogChannel Channel2_PC1 = Cpu.AnalogChannel.ANALOG_2;
            /// <summary>
            /// Analog input channel3 (pin PC3)
            /// </summary>
            public const Cpu.AnalogChannel Channel3_PC3 = Cpu.AnalogChannel.ANALOG_3;


            public const Cpu.AnalogChannel PA1 = Cpu.AnalogChannel.ANALOG_0; // precision=12
            public const Cpu.AnalogChannel PA2 = Cpu.AnalogChannel.ANALOG_1; // precision=12
            public const Cpu.AnalogChannel PA3 = Cpu.AnalogChannel.ANALOG_2; // precision=12
            public const Cpu.AnalogChannel PB0 = Cpu.AnalogChannel.ANALOG_3; // precision=12
            public const Cpu.AnalogChannel PB1 = Cpu.AnalogChannel.ANALOG_4; // precision=12
            public const Cpu.AnalogChannel PC4 = Cpu.AnalogChannel.ANALOG_5; // precision=12
            public const Cpu.AnalogChannel PC5 = Cpu.AnalogChannel.ANALOG_6; // precision=12
        }

        /// <summary>
        /// DAC Channels
        /// </summary>
        class DAC
        {
            /// <summary>
            /// Analog output channel0 (pin PA4)
            /// <para>Note: PA4 is also used by the ADC</para>
            /// </summary>
            public const Cpu.AnalogOutputChannel Channel0_PA4 = Cpu.AnalogOutputChannel.ANALOG_OUTPUT_0;
            /// <summary>
            /// Analog output channel1 (pin PA5)
            /// <para>Note: PA5 is also used by the ADC</para>
            /// </summary>
            public const Cpu.AnalogOutputChannel Channel1_PA5 = Cpu.AnalogOutputChannel.ANALOG_OUTPUT_1;

            public const Cpu.AnalogOutputChannel PA4 = Cpu.AnalogOutputChannel.ANALOG_OUTPUT_0; // precision=12
            public const Cpu.AnalogOutputChannel PA5 = Cpu.AnalogOutputChannel.ANALOG_OUTPUT_1; // precision=12
        }

        public static class AnalogOutputChannels
        {
            // ReSharper disable InconsistentNaming
            public const Cpu.AnalogOutputChannel PA4 = Cpu.AnalogOutputChannel.ANALOG_OUTPUT_0; // precision=12
            public const Cpu.AnalogOutputChannel PA5 = Cpu.AnalogOutputChannel.ANALOG_OUTPUT_1; // precision=12
                                                                                                // ReSharper restore InconsistentNaming
        }
}
