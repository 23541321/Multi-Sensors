/*
 * typedefs.h
 *
 *  Created on: 23 may. 2017
 *      Author: IbonZalbide
 */

#ifndef CONFIGURATION_H_
#define CONFIGURATION_H_

typedef enum
{
    CmdGetSensorValue = 0x00,
    CmdGetDR = 0x01,
    CmdSetDR = 0x02,
} r100DemoCmd_t;


typedef struct
{
uint16_t nSysTicksPerSample;
} r100DemoConf_t;

#endif /* TYPEDEFS_H_ */
