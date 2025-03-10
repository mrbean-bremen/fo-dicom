#### v.4.0.8 (TBD)
* Add missing properties to IDicomClient interface (#1171)
* Bug fix: No DICOM charset found for GB18030 in .NET Core (#1125)
* Bug fix: Incorrect failed validation for Vr Type DS, both .NET Core and Framework (#1141)
* Update to DICOM Standard 2021a. Nema now also provides Keywords for the UIDs, these are now used. Breaking change: some UID keywords have changed.
* Bug fix: Some non-retired DicomTags had a name including "RETIRED". Now fixed the generation of DicomTag names. (#1131)
* FrameGeometry is enhanced so that it also works for DX, CR or MG images. (#1138)
* Private Creator UN tags are converted to LO (#1146)
* Bug fix: Ensure timeout detection can never stop prematurely
* Fix parsing of datasets with a final SequenceDelimiterItem at the end (#1157)
* Fix: DicomDirectory did throw exception on calling constructor with no parameters (#1176)
* Update to DICOM Standard 2021b (#1189)

#### v.4.0.7 (11/1/2020)
* Bug fix: Not able to open deflated dicom file which contains squence (#1097)
* Bug fix: DS VR type value ending with \0 fails to serialize in JsonDicomConverter (#1078)
* Allow disabling validation in JsonDicomConverter
* Bug fix: IPv6 issue in DesktopNetworkStream
* Optimize DicomTag.GetHashCode() (#1088)
* Bug fix: Prevent special characters in association requests from crashing Fellow Oak DICOM (#1104)
* Fixes caching of pixel data in DicomImage when rendering the same image multithreaded. (#805)
* Fix handling of MaximumPDULength. DicomServer always repeated the clients value of MaximumPDULength in AssociationAccepted-message instead of returning its own value. (#1084)
* Bug fix: It's very slow to open deflated dicom file. (#1115)
* Bug fix: DicomUID Storage Commitment Push Model SOP Class was mapped to wrng DicomStorageCategory (#1113)
* Handle PresentationStates and StructuredReports when creating a DICOMDIR (#1045)
* Allow conversion of integerString into integer if original string had decimal with trailing zeros 
* Bug fix: String decimals ending in . (ex. 10.) throw DicomValidationException even though they can be converted to decimal
* Bug fix: FrameGeometry.PixelSpacingX and FrameGeometry.PixelSpacingY where wrong initialized. Now for clarity they are called PixelSpacingBetweenRows and PixelSpacingBetweenColumns.
* Bug fix: Date (DA) and DateTime (DT) fields didn't support range in validation (#1105)

#### v.4.0.6 (8/6/2020)
* Update to DICOM Standard 2020b.
* Handle N-Event requests in DicomClient (required for synchronous storage commitment) (#1001)
* Bug fix: Fix DICOM Tag conversion for private tags for element numbers xxff (#1059)
* ImplicitVRLittleEndian always added to presentation context by default causes other transfer syntax to not be accepted (#1048)
* New interface IDicomNEventReportRequestProvider for DicomServer. This is necessary to handle synchronous storage commitment on server (#1055)
* Bug fix: Fix the deserialization issue in JsonDicomConverter for NaN value in VR=FL (#1063)
* Bug fix: IOException when reading/sending file > 2GB. (#1061)
* Bug fix: DicomValidator ValidateLO issue, ESC is a valid character (#1043)
* Bug fix: DicomValidation for UI when AddFile to DicomDirectory (#1053)
* Bug fix: Exception occurred in Indexer of VOISequenceLUT Class (#1062)
* Bug fix: Prevent DicomClient getting stuck when any Exception (except IOException) occurs while sending a PDU over the network (#1054)
* Bug fix: Size of uncompressed YBR_FULL_422 images is calculated wrong (#645)
* Bug fix: YBR_FULL_422 images should have a planar configuration value of zero (#1049)
* When opening a DICOMDIR with invalid offsets, try to find the best matching records in a second run (#828)

#### v.4.0.5 (5/18/2020)
* Bug fix: DicomTags of ValueRepresentation LT have not been validated.
* Bug fix: Unawaited task throws unhandled exception caught in finalizer thread when stopping Dicom Server. (#1013)
* Bug fix: dependency of fo-dicom.ImageSharp nuget package was wrong. Now it also requires only netStandard1.3 (#1017)
* Bug fix: Fixed freeze when reading SQ of length 0 (#1009)
* Bug fix: DicomDictionary accessor thew exception on unknown keyword instead of returning null (#996)
* Update version of ImageSharp to rc1
* Bug fix: Comparing instance of class DicomStatus with null returned wrong value (#975)
* Bug fix: Overlay origin cannot be set correctly. (#1028)
* Add encoding to JsonDicomConverter on LO, SH and PN (#1020)

#### v.4.0.4 (1/17/2020)
* New feature: asynchronous counterparts to IDicomCEchoProvider, IDicomCFindProvider, IDicomCStoreProvider, IDicomCMoveProvider, IDicomCGetProvider and IDicomNServiceProvider
* Bug fix: Prevent SSL handshake freeze from blocking the TCP listener (#923)
* disable validation when cloning/copying existing DicomDatasets. Exceptions has been thrown when anonymizing files that contain invalid content.
* Bug fix: FileReadOption.SkipLargeTags caused that only parts of a FragmentSequece have been read, which then lead to further errors. Now the whole FragmentSequence is skipped if only one part of this sequence is skipped.
* Bug fix: Exception when anonymizing private tags, where the value representation is not known.
* Implementation of IImage with ImageSharp, which is pure managed and can be used on any operation system. (#693)
* Add link to wiki entry in DicomCodecException (#948)
* Bug fix: DicomDataset.TryGetString throws if the element is an empty number-based element (#932)
* Bug fix: Some continuations in the new DicomClient were not properly marked with ConfigureAwait, which could cause trouble
* Bug fix: VOI LUT was not applied correctly (#949)
* Add ReferencedFilmSessionSequence in N-Create message of BasicFilmBox (#967)
* Bug fix: Exception when cloning to Jpeg Process2_4 when parameters are set to null.

#### v.4.0.3 (9/21/2019)
* Bug fix: Exception when adding an element of VR UR/UT/LT/ST with empty value (#915)
* Bug fix: Exception when opening a file with FileReadOption.SkipLargeTags (#893)
* Bug fix: Do not open new associations on the existing TCP connection (#896)
* Bug fix: Broken images when transcoding to JpegProces14 (#921)
* New feature: Add the ability to enforce a maximum number of DICOM requests per association to the new DICOM client (#898)
* Add AutoValidate property also to DicomDirectory class.
* Add support for timeout detection on DICOM requests. Events on Requests and DicomClient are thrown in case of timeout (#666, #236)
* New Option MaxPDULength in DicomServiceOption.
* Rewrite SOP class extended negotiation support (#740)
* Bug fix: extended negotiations have been accepted by default, but should be explicitly accepted (#900)
* Bug fix: Send only PrintManagementMetaSopClassUid on AssociationRequest instead of all the various SopClassUids of the NCreate and NSet requests (#667)
* Global static property DicomValidation.PerformValidation to turn off validation for every DicomDataset. 
* Bug fix: Prevent DICOM client from freezing when too many DICOM requests time out and async operations invoked is a low number

#### v.4.0.2 (7/30/2019)
* Bug fix: prevent resource leak when DesktopNetworkListener waits for new TCP clients
* Updated to DICOM Dictionary 2019a (#724)
* Add pure managed JpegLosses Decoder to DICOM.NetCore project
* Upgraded native libraries to MSVC platform toolset v141 (VS 2017) (#814)
* Replaced deprecated licenseUrl tags in NuGet specification files (#813)
* Add validation of content when adding DICOM elements to DicomDataset. This validation is skipped when reading files or receiving data via network.
* Be more prudent when releasing association after the linger timeout (#840)
* A completely new DicomClient, under the namespace Dicom.Network.Client.DicomClient (beware of confusion with Dicom.Network.DicomClient!)
  * The intent is that the old Dicom.Network.DicomClient will disappear in the next major update, so the namespace confusion shouldn't last very long.
  * For now, both versions can be used side by side according to your needs. All of our unit tests cover both implementations. 
  * The new Dicom.Network.Client.DicomClient sports the following characteristics:
    * Redesigned architecture using state pattern. This makes the DicomClient a lot more robust in various scenarios (abort while sending requests, disconnect while releasing association, etc)
    * Completely async from the very start
    * Full and graceful cancellation support using CancellationToken. Upon cancellation, no more requests will be sent, the association will be released and the connection closed gracefully.
    * One DicomClient instance per DICOM server. The host, port and other server related parameters are moved to the DicomClient constructor.
    * More hooks to react to the various states a DicomClient goes through. (e.g. when connecting, when lingering the association, etc.)
* Bug Fix: Fixed wrong interpretation and application of LUT for PALETTE COLOR images (#817)
* Bug Fix: Allow any SOP Class to be set as Affected SOP CLass in C-FIND requests (#808)
* Bug Fix: Don't drop connection right after releasing an association (#839)
* Bug Fix: Wait for release of previous association before opening a new one  (#833)
* Bug Fix: When a connection is still open but the association is already released, create a new association (#833)
* Bug Fix: When adding datasets to a DicomDirectory where some patientNames have trailing ^, then they were not recognized as one patient (#765)
* Bug Fix: Anonymizer throws exception on private tags (#771)
* Bug Fix: Linear windowing wrong in corner cases (#816)
* Bug Fix: Fix DicomClient getting stuck when sending one request fails completely (#848)
* Added Modality LUT Sequence and VOI LUT Sequence functionality when generating a DICOM Image.
* Bug Fix: Logging requests with very long private tags throws exception (#846)
* Bug Fix: turn off validation when creating CFind-, CGet- or CMove-Requests, since there are no newly generated data included, but already existing UIDs have to be added there. (#860, #842)
* Bug Fix: generation of DicomUID using obsolete method Generate("name") resulted in invalid UIDs. (#862)
* Bug Fix: Disabling dataset validation for file meta information objects. (#859)
* Bug Fix: JPEG 2000 decodes wrong colors in .NET Core (#850)
* Enable secure DICOM Tls 1.0, 1.1 and 1.2 (#872)
* Set text encoding of Json to UTF-8, as defined in dicom standard F.2
* Bug Fix: Photometric Interpretation updates on Transfer Syntax changes (#836)
* Bug Fix: DicomOverlayData OriginX and OriginY were swapped
* Bug Fix: Handle Json deserializing of empty values (#873)

#### v.4.0.1 (3/13/2019)
* change IFileReference and IByteBuffer to have offset of type long so that big files can be processed (#743)
* internally identify dicom servers by port/ipadress combination instead of only port (#699)
* DicomDirectory.AddFile returns a reference to the newly added patient-, study-, series- and instance-Record.
* Update Json DS validation regex (#643)
* Add option to DicomFile.Open how to deal with large tags (#617)
* DicomFileMetaInformation now uses pre-existing SourceAET where possible
* PixelData.GetMinMax now has 2 overloads, one that takes padding into account and one wihtout the padding parameter (#675)
* string.ToUpper() is replaced by string.ToUpperInvariant() to prevent bad character conversion on turkish system
* Fix detecting default windowing if a dataset contains several windows configurations (#741)
* Fix bug in .net core when a image is both flipped in x and y direction (#721)
* Pass through the timeout parameter from DicomClient.Send to the constructor of DesktopNetworkStream (#732)
* Added appveyor.yml file for ci by this setting (#729)
* Bug Fix : anonymized patient name is now encoded with same character set as the original Dicom.
* add DicomUID.IsVolumeStorage.
* Bug Fix : DICOM server may throw DicomDataException on association when non-standard transfer syntax was proposed (#749)
* allow Query/Register/Unregister transfer syntax.
* DicomCFindRequest should allow defnition of Query Retrieve Information Model (#708)
* Bug fix : DicomUIDGenerator.GenerateDerivedFromUUID converts Guids incorrectly to the DICOM "2.25." + UUID format (#762)
* Bug Fix : TryGetValue, TryGetValues, TryGetSingleValue should return false instead of throw exception. (#746)
* Add methods to calculate localizer lines (#779)
* Bug Fix : DicomPixelData.Create throws Exception if BitsAllocated >= 32 (#716)
* Bug Fix: GetValues<object> on empty element may throw ArgumentOutOfRangeException (#720)
* Serilog for .NET Standard 1.3/.NET Core (#772)
* Bug Fix : DicomServer does not close TcpClient/socket after client closed connection (#795)
* Bug Fix : JsonDicomConverter should decode BulkDataURI element(#796)
* Bug Fix: fix deserialization of Json when the VR-property is not on first position (#730) 
* DicomClient uses StrongBox to reduce memory consumption (#794)
* Bug Fix: C-STORE request may hang. (#792)

#### v.4.0.0 (9/24/2018)
* Demonstrate and fix error in RLELossless Transfer Syntax Codec
* Fixing 2 UWP Networking Bugs (#636, #637)
* Add List of known Private UID's (#589)
* DicomReader: Prevent premature exit from privateBadSequence when private sequence contains sub-sequence (#565 #626)
* Saving a file with deflated transfer syntax occasionally fails (#621)
* Anonymizer not removing Sequences (#610 #611)
* Deprecate DicomClient.WaitForAssociation and provide association events (#605 #609)
* Subclassing DicomServer (#602 #604)
* Support CP-1066 (#597 #606)
* DicomDataset.Add and .AddOrUpdate overloads with Encoding parameter (#596 #607)
* Code generator support for anonymization data (#594 #595)
* DicomServer to listen on IPv6 socket (#588 #604)
* DicomAnonymizer blank DicomDate/DicomDateTime to DateTime.MinValue instead of empty value (#576 #593)
* DicomAnonymizer ignores the PatientName and PatientID in the SecurityProfile (#575 #592)
* Private group not added to tag when private tag item is added to dataset (#570 #577)
* ReceivingApplicationEntityTitle and SendingApplicationEntityTitle omitted during Save (#563 #569)
* Downgrade desktop libraries to framework version 4.5 (#561 #562)
* Add support for Unity 2017.1 platform (#560 #585)
* Handle fragmented OW pixel data when creating EncapsulatedPixelData for new pixel data (#553 #586) 
* DicomImage is not thread safe (#552 #582)
* DicomUIDGenerator.Generate UID Collisions (Non-unique UIDs) (#546 #571)
* Correct interpolation of rescaled overlay graphics (#545 #558)
* Some getters of optional sequences do not account for missing sequence (#544 #572)
* A-ASSOCIATE-AC PDU parsing incorrect (#543 #583 #590 #591)
* DicomCFindRequest is unsuitable for "Search for Unified Procedure Step (C-FIND)" (#540 #580)
* DicomClient proposes wrong presentation context in .NET core with codec that does not support 16 bit encoding (#538 #600)
* Private tag is listed out or order (#535 #566)
* JsonDicomConverter.ParseTag is very slow for keyword lookups (#533 #531)
* DicomDictionary.GetEnumerator() is very slow (#532 #534)
* DicomPixelData.BitsAllocated setter removed (#528 #564)
* Complete list of transfer syntax fields from the DICOM Standard (#526 #599)
* DicomClient.SendAsync will never return when certain non-transient exceptions are thrown (#525 #584)
* CStore-SCU always adds a PC with LEExplicit and LEImplicit (#524 #541)
* Added Maximum Clients Allowed to restrict connection to SCP (#523 #573)
* Updated JPEG-LS to latest CharLS commit (#517)
* Support for anonymization, deflated and compressed transfer syntaxes on Unity (#496)
* Support for up to 16 bit JPEG 2000 codecs on Android, iOS, Mono and .NET Core (#496)
* Added missing encodings for .NET Core (#481 #486)
* Update to latest DICOM Standard 2018b (#480 #482 #536 #537 #555 #559 #619 #676)
* Convert .NET Core projects to use VS 2017 .csproj project files (#470 #473)
* Add TextWriterLogger (#461 #542)
* Call to DicomServer.Stop does not remove all clients (#456 #464)
* Repository re-organization (#445 #446 #447 #448 #451 #452 #455 #462 #463 #465 #467 #468 #469 #476 #477 #478)
* Hololens support on Unity (#431 #556)
* Deprecate Legacy class library (#415 #449)
* Provide System.Drawing.Bitmap support for image rendering with .NET Core (#409 #450 #459)
* Added optional parameter for use in extended DicomService (#348 #441)
* Consistently asynchronous networking API (#331 #584)
* Pass through unsupported user data during PDU parsing (#242 #443)
* Remove warning messages during build (#33 #438)
* Online and NuGet packages API documentation (#28 #459 #466 #574 #584)
* Status code in respose got lost and mapped to an internally known status code (#616)
* WinFormsImage may throw exception on Dispose or on GC (#634)
* Fix StackOverflowException in Vector3D multiplication (#640)

#### v.3.0.2 (4/20/2017)
* DicomRejectReason enumerables should be parsed w.r.t. source (#516 #521)
* Incorrect numerical value on RejectReason.ProtocolVersionNotSupported (#515 #520)
* Add private creator to private tags when deserializing json (#512 #513)
* Adding private tags implicitly uses wrong VR (#503 #504)
* Add option in DicomServiceOptions for max PDVs per PDU (#502 #506)
* DicomResponse.ErrorComment is always added in the DicomResponse.Status setter, even for successes (#501 #505)
* DicomStatus.Lookup does not consider priority in matching (#499 #498)
* DesktopNetworkListener can throw an exception which causes DicomServer to stop listening (#495 #519)
* Cannot create DICOMDIR after anonymizing images (#488 #522)
* Cannot parse dicom files if the last tag is a private sequence containing only empty sequence items (#487 #518)
* If the connection is closed by the host, DicomClient will keep trying to send (#472 #489)
* N-CREATE response constructor throws when request command does not contain SOP Instance UID (#484 #485)
* Cannot render YBR_FULL/PARTIAL_422 with odd number of columns (#471 #479)
* Dicom Server listener consumes large amount of memory if http request is sent to listener (#327 #509)

#### v.3.0.1 (3/06/2017)
* Add runtime directives to enable .NET Native builds for UWP (#424 #460)
* YBR_FULL_422 JPEG Process 14 SV1 compressed image incorrectly decoded (#453 #454)

#### v.3.0.0 (2/15/2017)
* DICOM Anonymizer preview (#410 #437)
* Client should not send if association rejected (#433 #434)
* Deploy error for Unity based applications on Hololens (#431 #432)
* Add method "AddOrUpdatePixelData" to the DicomDataset (#427 #430)
* Adding too many presentation contexts causes null reference exception in DicomClient.Send (#426 #429)
* Serialize to XML according to DICOM standard PS 3.19, Section A (#425)
* Invalid reference in Universal targets build file (#422 #423)
* Alpha component is zero for color images on UWP, .NET Core and Xamarin platforms (#421 #428)
* Print SCP exception due to insufficient DicomDataset.AddOrUpdate refactoring (#353 #420)
* Invalid decoding of JPEG baseline RGB images with managed JPEG codec (#417 #419)
* DicomFile.Save throwing an exception in DotNetCore for macOS (#411 #413)
* Added method GenerateUuidDerived (#408)
* Padding argument not accounted for in some IPixelData.GetMinMax implementations (#406 #414)
* Incorrect handling of padded buffer end in EvenLengthBuffer.GetByteRange (#405 #412)
* Unhandled exception after error in JPEG native decoding (#394 #399)
* DicomDataset.Get&lt;T[]&gt; on empty tag should not throw (#392 #398)
* Efilm 2.1.2 seems to send funny presentation contexts, break on PDU.read (#391 #397)
* Improved reliability in DicomClient.Send (#389 #407)
* Cannot catch exceptions while doing C-STORE if I close my network connection (#385 #390)
* Handle UN encode group lengths and missing last item delimitation tag (#378 #388)
* Invalid handling of overlay data type, description, subtype and label (#375 #382)
* Incorrect message logged when async ops are not available, but requested (#374 #381)
* Fix get object for all DicomValueElement inheritors (#367 #368)
* Handle parsing sequence items not associated with any sequence (#364 #383 #435 #436)
* System Out Of Memory Exception when saving large DICOM files (#363 #384)
* Null characters not trimmed from string values (#359 #380)
* Corrected JPEG-LS encoding and JPEG decoding for YBR images (#358 #379 #416 #418)
* Cannot override CreateCStoreReceiveStream due to private fields (#357 #386)
* DicomClient multiple C-Store request cause exception when AsyncOps is not negotiated (#356 #400)
* Enable registration of private UIDs (#355 #387)
* DICOM Parse error - Stack empty (#342)
* Invalid abort upon exception in P-Data-TF PDU processing (#341 #401)
* Sufficient image creation when Bits Allocated does not match destination type size (#340 #350)
* Some Dicom Printer refuse print requests from fo-dicom (#336)
* DicomContentItem.Children() throws exception when there are no children (#332 #333)
* Functional changes in Dataset.Add, rename of ChangeTransferSyntax (#330 #343)
* Added support for more date/time formats (#328 #352)
* Exception if Storage Commitment N-Event Report response does not contain EventID tag  (#323 #329)
* ImageDisposableBase implicit destructor missing (#322 #326)
* Dicom Response Message should be sent using the same Presentation Context in the Request (#321)
* DicomDataset.Contains(DicomTag tag) matches on object, will not find private tags (#319 #351)
* Add DICOM VR Codes as constants (#315)
* DicomClient should be able to C-STORE non-Part 10 DICOM files (#306 #307)
* Incorrect dependency in fo-dicom.Universal.nuspec (#300 #301)
* GetDateTime method does not handle missing date and time tags (#299 #302)
* Print SCP sample reports exception due to missing ActionTypeID in N-ACTION response (#298 #308)
* Red and Blue bytes swapped in color images on iOS (#290 #291)
* Support creating DS Value elements from string and IByteBuffer (#288)
* Pixel Data not null-padded to even length (#284 #286)
* Merge core and platform assemblies (#280 #283)
* ChangeTransferSyntax throws an exception (J2k 16-bit -&gt; Jpeg Lossy P 4) (#277 #281)
* Merge DicomUID partial files (#268 #270)
* Wrong description for some tags (#266 #271)
* DicomFileMetaInformation overly intrusive (#265 #285)
* Type 3 property getters in DicomFileMetaInformation throw when tag not defined (#262 #264)
* Invalid DicomDateTime output format (#261 #269)
* NLog Formatted Logging Failing (#258 #260)
* .NET Core Library Build Request (#256 #294 #296 #297 #310 #311 #325 #334)
* Adaptations for fo-dicom on Unity platform (#251 #252 #253 #255 #257 #263 #287 #289 #292 #293)
* Log4net event logging config not working with AssemblyInfo.cs XMLConfigurator (#244 #248)
* Implement SOP Class Extended Negotiation (#241 #243 #304 #305)
* DicomClient.Send DicomAssociationRejectedException not working (#239 #249)
* Dicom.Platform.rd.xml file should be included as Embedded Resource (#237 #247)
* DicomIntegerString.Get&lt;T&gt;() throws for enums and non-int value types (#231 #212 #226)
* Upgrade dictionary to latest DICOM version 2016e (#229 #233 #245 #246 #317 #318 #360 #362 #372 #373)
* Deflate Transfersyntax (#227 #259)
* Use an editorconfig-file (#216 #215)
* Upgrade to Visual Studio 2015 toolset (#214 #217)
* Limited debug info for DicomDataset (#210 #211)
* Allow specifying AbstractSyntax distinct from RequestedSOPClassUID (#208 #209)
* Separate NuGet packages for all supported platforms (#206 #207 #275 #282)
* Support more date-time parser formats (#205)
* DicomDecimalString constructor fails with decimals if CurrentCulture has decimal commas (#202 #203)
* Add VR Other Long (OL) (#201 #232)
* Improved reliability in network operations (#199 #234 #312 #314 #316 #324)
* If DicomServer already running, get instance of them (#191 #250)
* Implement JSON serialization and deserialization of DICOM objects (#182 #186)
* Open and save DicomDirectory to Stream (#181 #235)
* Implement C-GET support (#180 #309)
* Exposing network infos (ip and port) in association (#173 #225 #377)
* Consider implementing DicomDataset.Clone() as "DeepClone" (#153 #313)
* Image compression/decompression for Mono and Xamarin (#128 #279 #295)

#### v2.0.2 (2/15/2016)
* "Index was outside the bounds of the array" in PrecalculatedLUT indexer (#219 #221)
* DicomReader reads past end of file if empty private sequence is last attribute in dataset (#220 #222)
* DicomReader reads past end of file if first private sequence item is zero length (#223 #224)

#### v2.0.1 (1/22/2016)
* DICOM CP-246 not handled correctly in DicomReader (#177 #192)
* Fix for #64 breaks parsing of valid datasets (#178 #184 #194)
* Invalid VR in explicit dataset leads to 'silent' stop (#179 #196)
* DicomDictionary.UnknownTag missing new VRs OD, UC and UR (#183 #185)
* DicomPixelData.Create is broken for signed pixel data with BitsAllocated != BitsStored (#187 #189)
* CompositeByteBuffer ArgumentException (#195 #198)

#### v2.0.0 (1/14/2016)
* Removed Modality Dicom Tag in Study Request (#166)
* Checking for valid Window Center and Window Width values before using in GrayscaleRenderOptions (#161 #163)
* Initialize managers automatically via reflection (#148 #149)
* Message Command Field Priority invalid for C-ECHO and all DIMSE-N Requests (#141 #143)
* Overlay data error corrections (#110 #138 #140)
* Report status for additional presentation contexts (#137 #139)
* Extended stop parsing functionality with support e.g. for sequence depth (#136 #142)
* Handle simultaneous use of explicit sequence length and sequence delimitation item (#64 #135)
* Parse error when encapsulated pixel data appears inside sequence item (#133 #134)
* Universal Windows Platform library with networking, imaging and transcoding capability (#118 #124 #125 #126 #132)
* Improved exception reporting for NLog (#121 #122)
* MetroLog connector is Portable Class Library (#119 #120)
* Fix of concurrency bugs in DicomDictionary (#114 #115 #151 #152)
* Xamarin Android platform library with imaging cabability (#113 #117)
* Xamarin iOS platform library with imaging cabability (#111 #112)
* Portable Core and platform-specific assemblies, including basic Mono implementation (#13 #93 #94 #60 #109)
* Network abstraction layer (#86 #106 #156 #159 #160 #157 #164 #158 #165 #167 #175)
* Transcoder abstraction layer (#102 #105)
* Synchronized LogManager API with other managers (#103 #104)
* Image abstraction layer (#83 #85 #92 #101 #144 #145 #150)
* I/O abstraction layer (#69 #78 #97 #100)
* Provide Task Asynchronous Pattern (async/await) for file I/O and network operations (#65 #90 #96 #98 #99 #107 #116 #130 #131)
* Provide NullLogger for disabled logging (#89 #91)
* Improved NuGet installation procedure for codec assemblies (#87 #88 #123)
* DICOM Dump can ignore private dictionary (#84)
* API for applying color LUT on grayscale image (#79 #81 #146 #147)
* Log4Net connector and NuGet package (#76 #77)
* JPEG, JPEG-LS and JPEG2000 source code updated to latest applicable version (#74 #75)
* Reverted memory mapped file implementation for image loading (#71 #72 #73)
* MetroLog connector and NuGet package (#59 #68)

#### v1.1.0 (8/10/2015)
* Enable configuration of default encoding in the DicomDatasetReaderObserver (#54)
* DicomDataset.Add(DicomTag, ...) method does not support multi-valued LO, PN, SH and UI tags (#51)
* Explicit VR file parsing failures due to strictness (#47)
* Overlay scaling in WPF images (#46)
* Prevent non-socket related exceptions from being swallowed (#45)
* Codec loading - add logging and default the search filter wildcard (#41)
* Use memory mapped file buffer to improve large image reading (#17)
* Improved reliability in search for native codec assemblies (#14)
* Consistent handling of Get&lt;T&gt; default values (#10)
* DICOM dictionary (tags and UIDs) updated to version 2015c (#9, #44)
* UC, UR and OD value representations added (#9, #48)
* Serilog support added; NLog and Serilog loggers moved to separate assemblies (#8, #34)
* Corrected Color32.B getter (#7)
* Upgraded to .NET 4.5 and C/C++ toolset v120 (#4)
* Use UTF-8 encoding where appropriate (#2, #20, #21)
* Fixed JPEG Codec memory corruption when encoding decoding on the same process for long period (#1)

#### v1.0.38 (withdrawn)
* Fix OW swap for single byte images
* Better handling of long duration and aborted connections
* Many imported extensions and bug fixes!

#### v1.0.37 (2/19/2014)
* Add DICOM Compare tool to project
* Add support for disabling TCP Nagle algorithm
* Better handling of aborted connections
* Fix some UID values containing encoding characters
* Fix extraction of embedded overlays
* Utility methods for calculating window/level
* Use number keys to change W/L calculation mode in dump utility
* Use O key to show/hide overlays in dump utility
* Fix byte swapping for Implicit VR single byte images

#### v1.0.36 (8/6/2013)
* Fix bug sorting private tags
* Ability to add private tags to dataset
* Better handling of improperly encoded private sequences
* Fix bug adding presentation contexts from requests
* Fix typo in N-Set response handler

#### v1.0.35 (7/5/2013)
* Fix bug adding presentation contexts with Implicit Little Endian syntax
* Add option to use the remote AE Title as the logger name
* Miscellaneous improvements and fixes

#### v1.0.34 (6/27/2013)
* Fix bug returning default value for zero length elements
* Fix exception when disposing DicomDirectory
* Fix menu bug in DICOM Dump utility when changing syntax to JPEG Lossless
* Fix bug matching private DICOM tags
* Add classes for basic structured report creation
* Ability to browse multiframe images in DICOM Dump utility
* Ability to recover when parsing invalid sequences
* Ability to parse improperly encoded private sequences

#### v1.0.33 (4/28/2013)
* Add logging abstraction layer to remove runtime dependency on NLog
* Fix bug reading duplicate entries in DICOM dictionary
* Fix bug storing AT values
* Fix bug sorting private DICOM tags
* Fix bug using custom DicomWriteOptions

#### v1.0.32 (3/12/2013)
* DICOM Media example by Hesham Desouky
* Move DicomFileScanner to Dicom.Media namespace
* Add WriteToConsole logging extension method
* Increase line length of dataset logging extension methods
* Fix reading of sequences in DICOMDIR files (Hesham Desouky)
* Improve rendering performance by precalculating grayscale LUT
* Ability to render single-bit images
* Fix hash code implementation for private tags
* Miscellaneous improvements and fixes

#### v1.0.31 (1/13/2013)
* Improved portability and fewer compiler warnings (Anders Gustafsson)
* Ensure frame buffers created by codecs have even length
* Import DicomFileScanner from mDCM
* Ability to save datasets and images in DICOM Dump utility
* Ability to change tranfer syntax in DICOM Dump utility
* Fix loss of embedded overlay data during compression
* Fix rendering of big endian images
* Miscellaneous improvements and fixes

#### v1.0.30 (1/1/2013)
* Fix bug rescaling DicomImage (Mahesh Dubey)
* Add rules for matching and transforming DICOM datasets
* Miscellaneous improvements and fixes

#### v1.0.29 (12/22/2012)
* Minor modifications to facilitate library porting to Windows Store apps (Anders Gustafsson)
* Convert unit tests to use MS Unit Testing framework
* Move DICOMDIR classes back to Dicom.Media namespace
* Change DicomDirectory Open/Save methods to be consistent with DicomFile usage
* Fix bug decoding single frame from a multiframe image (Mahesh Dubey)

#### v1.0.28 (12/12/2012)
* Display exception message in DICOM Dump for image rendering errors
* Remove serialization members
* Fix bug where frame is not added to OtherWordPixelData (Mahesh Dubey)
* Fix bug where exception is not thrown for out of range frame numbers in GetFrame() (Mahesh Dubey)
* Fix bug where internal transfer syntax is not set when transcoding file (Mahesh Dubey)
* Add request/response classes for DICOM Normalized services
* Change DicomCStoreRequest constructor to use SOP Class/Instance UIDs from dataset instead of FMI
* Experimental support for DICOM directory files (Hesham Desouky)

#### v1.0.27 (10/30/2012)
* Ensure that file handles are closed after opening or saving DICOM file
* Add ability to move file pointed to by FileReference
* Fix window/level settings not being applied to rendered DicomImage
* Fix processing order of received DIMSE responses
* Process P-Data-TF PDUs on ThreadPool
* Temporary fix for rendering JPEG compressed YBR images
* Fix Async Ops window for associations where it is not negotiated
* Fix bug reading Palette Color LUT with implicit length
* Support decompression and rendering of JPEG Process 2 images
* Enable modification of Window/Level in DicomImage

#### v1.0.26 (10/19/2012)
* Advanced DIMSE logging options for DicomService base class
* Advanced configuration options for P-Data-TF PDU buffer lengths
* Fix bug where final PDV may not be written to P-Data-TF PDU
* Fix bug reading DIMSE datasets from network

#### v1.0.25 (10/18/2012)
* Fix min/max pixel value calculation for unsigned 32-bit pixel values
* Fix collection modified exception when calculating group lengths
* Better handling of null values when adding elements to dataset
* Fix default values when accessing SS/US element values (Anders Gustafsson, Cureos AB)
* Fix decoding of JPEG2000 images with signed pixel data (Mahesh Dubey)
* Ability to decompress single frame from dataset (Mahesh Dubey)
* Use ThreadPoolQueue to process related response messages in order

#### v1.0.24 (10/01/2012)
* Change the default presentation context transfer syntax acceptance behavior to prefer the SCU proposed order
* Reject all presentation contexts that have not already been accepted or rejected when sending association accept
* Add finalizers to temp file classes to catch files not deleted at application exit
* Remove Exists() method from DicomDataset (duplicates functionality of Contains())
* Extension methods for recalculating and removing group length elements
* Force calculation of group lengths when writing File Meta Info and Command datasets
* Fix exception when attempting to display ROI overlays
* Add ability to extract embedded overlays from pixel data
* Detect incorrect transfer syntax in file meta info
* Add support for reading and displaying GE Private Implicit VR Big Endian syntax

#### v1.0.23 (09/26/2012)
* Fix W/L calculation creating negative window width
* Round VOI LUT values instead of casting away fraction
* Fix bug reading signed pixel data from buffer
* Fix encoding of JPEG2000 images with signed pixel data
* Throttle queueing of PDUs to prevent out of memory errors for very large datasets
* Better management of PDU buffer memory
* Better handling for irregular specific character sets
* Support displaying images without specified photometric interpretation
* Ability to read files without preamble or file meta information (including ACR-NEMA)

#### v1.0.22 (09/25/2012)
* Add Offending Element tags to C-Move response output
* Add exception handling for C-Store requests with unparsable datasets
* Handle ObjectDisposedExceptions in network operations
* Fix transcoding between uncompressed transfer syntaxes
* Don't parse values for IS and DS elements if returning string types
* Add AMICAS private tags (AMICAS0) to private dictionary
* Add support for 32-bit pixel data (Anders Gustafsson, Cureos AB)
* Better handling of default item in Get&lt;&gt; method (Anders Gustafsson, Cureos AB)
* Support opening DicomFile from Stream (Anders Gustafsson, Cureos AB)
* Add support SIGMOID VOI LUT function
* Better handling of size and position of image display window in DICOM Dump
* Fix calculation of W/L from smallest/largest pixel value elements
* Fix viewing of images with bits allocated == 16 and bits stored == 8
* Add support for image scaling in DicomImage
* Use library to scale images before displaying in DICOM Dump
* Calculate W/L from pixel data values if no defaults are available
* Add ability to Get&lt;&gt; Int32 values from US/SS elements
* Add ability to Get&lt;&gt; DicomVR and IByteBuffer from elements
* Add ability to Get&lt;&gt; byte[] from elements
* Add ability to render basic PALETTE COLOR images
* Fix unnecessary byte swap for 8-bit pixel data stored in OW
* Add DicomFileException to allow better chance of recovery from parse errors
* Add maximum PDU length to association output
* Fix major bug in writing PDataTF PDUs; improvements in performance and memory usage
* Add ability to propose additional transfer syntaxes in C-Store request

#### v1.0.21 (09/14/2012)
* Add connection close event and socket error handlers to DicomService
* Fix C-Store SCP example's constructor not passing logger

#### v1.0.20 (09/13/2012)
* Fix exception in DicomClient when releasing association

#### v1.0.19 (09/13/2012)
* Force passing of Logger to DicomService constructor (may be null)

#### v1.0.18 (09/13/2012)
* Print Offending Element values when outputing request to log
* Add ability to pass custom logger to DicomService based classes

#### v1.0.17 (09/12/2012)
* Check overlay group before attempting to load overlay data
* Add ability to copy value column to clipboard in DICOM Dump
* Fix DicomClient linger timeout and add release timeout

#### v1.0.16 (09/11/2012)
* Fix decompression of JPEG Baseline Process 1 images
* Fix conversion of YBR to RGB in JPEG compressed images
* Add ability to handle encapsulated OW pixel data
* Better handling of grayscale images without Window/Level in dataset

#### v1.0.15 (09/06/2012)
* Add ability to store user state object in DicomService based classes
* Add ability to store user state object in DicomClient
* Fix handling of UIDs in DicomCFindRequest
* Fix comparison of private DicomTags
* Add shortcut constructor for private DicomTags
* Handle null DicomDateRange in DicomDataset.Add()
* Modality Worklist C-Find helper method

#### v1.0.14 (09/05/2012)
* Fix bug in DicomDatasetReaderObserver handling zero length Specific Character Set elements
* Fix bug in DICOM Dump when displaying zero length UIDs
* Load implementation version from assembly info

#### v1.0.13 (09/04/2012)
* Add ability for library to create and manage temp files
* User state object for DIMSE requests and responses
* Fix reading of elements with unknown dictionary VR (Justin Wake)
* Fix handling of UIDs in DicomCMoveRequest (Justin Wake)
* Add version to file meta information
* Add support for multiframe images in DicomImage

#### v1.0.12 (08/27/2012)
* Add private dictionary to assembly
* Fix parsing errors when reading private dictionaries
* Fix reading of private tags
* Miscellaneous enhancements

#### v1.0.11 (08/23/2012)
* Accept unknown transfer syntaxes
* Add ability to write DICOM dataset to string

#### v1.0.10 (08/13/2012)
* Fix bug preloading dictionary from another assembly (Mahesh Dubey)
* Add name of UID to DICOM Dump elements
* Better error handling in GetDateTime method
* Persistent temporary file remover

#### v1.0.9 (08/02/2012)
* Parsing of Attribute Tag element type
* Fix bug displaying compressed images
* Add codec libraries as references to DICOM Dump utility
* Fix bug writing private sequence lengths
* Fix stack overflow when reading datasets with lots of sequences
* Fix big endian pixel data being swapped twice

#### v1.0.7 (07/26/2012)
* Fix exception when accessing overlay data
* Fix parsing of multi-value string elements
* Add option to display image in DICOM Dump utility
* Fix C-Store request from Conquest causing exception

#### v1.0.6 (07/24/2012)
* Don't throw exception for invalid UID characters
* Allow casting of OB & UN elements to value types

#### v1.0.5 (07/22/2012)
* Bug fixes
* DICOM Dump example project

#### v1.0.4 (07/18/2012)
* Make logger instance protected in DicomService
* Lock DICOM dictionary while loading
* Throw exception if no DICOM dictionary entry is found while adding element to dataset
* Fix bug where status is not being set in DIMSE response
* Fix bug in C-Store SCP where file is inaccessible
* Add C-Store SCP example project

#### v1.0.3 (07/11/2012)
* Fix parsing of explicit length sequences

#### v1.0.2 (07/07/2012)
* Image rendering
* Don't create offset table for datasets over 4Gb
* Regenerate dictionary and tags to include grouped elements such as overlays
* Fix bug in ByteBufferEnumerator

#### v1.0.1 (06/22/2012)
* Initial public release
